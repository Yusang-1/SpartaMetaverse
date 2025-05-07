using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float smoothing = 0.2f;
    [SerializeField] Vector2 min;
    [SerializeField] Vector2 max;
    private void FixedUpdate()
    {
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, this.transform.position.z);

        targetPosition.x = Mathf.Clamp(targetPosition.x, min.x, max.x);
        targetPosition.y = Mathf.Clamp(targetPosition.y, min.y, max.y);

        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
    }
}
