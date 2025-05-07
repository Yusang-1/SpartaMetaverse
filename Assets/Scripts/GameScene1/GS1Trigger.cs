using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GS1Trigger : MonoBehaviour
{
    [SerializeField] Transform target;
    private void Update()
    {
        Vector3 vec = transform.position;
        vec.x = target.position.x - 17.15f;
        transform.position = vec;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Æ®¸®°Å");
        if (collision.tag == "Triggerable1")
        {
            collision.gameObject.SetActive(false);
            GS1Manager.Instance.SetBackGround();

        }
        else if (collision.tag == "Triggerable2")
        {
            collision.gameObject.SetActive(false);
            GS1Manager.Instance.SetObstacle();
            
        }
    }
}
