using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS1Camera : MonoBehaviour
{
    [SerializeField] Transform Target;
    [SerializeField] float min;
    [SerializeField] float max;
    [SerializeField] float smoothness;
    void Update()
    {
        float y = Mathf.Clamp(Target.position.y, min, max);
        Vector3 cameraPosition = new Vector3(Target.position.x + 3.15f, y, -10);
        transform.position = Vector3.Lerp(transform.position, cameraPosition, smoothness);
    }
}
