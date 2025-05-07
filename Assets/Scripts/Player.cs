using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    Camera cam;
    [SerializeField] ConvManager convManager;
    Vector3 dirVec;
    Vector3 prevVec;
    GameObject scanObject;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        //convManager = GetComponent<ConvManager>();
    }

    void Update()
    {
        Vector3 vec = rigid.position;
        Vector3 mouseVec = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rayVec = mouseVec - vec;
        Debug.DrawRay(vec, rayVec.normalized, new Color(1, 0, 0));

        if (Input.GetKeyDown(KeyCode.E) && scanObject != null)
        {
            Debug.Log(scanObject.name);
            convManager.ConversationSetting(scanObject);
        }
    }

    private void FixedUpdate()
    {
        PlayerMove();
        PlayerRaycast();
        
    }

    void PlayerMove()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector2 vec = new Vector2(horizontal, vertical);
        rigid.velocity = vec * 3;
    }

    Vector3 PlayerDirection()
    {
        if (!Input.GetButton("Horizontal") && !Input.GetButton("Vertical")) return prevVec;

        if (rigid.velocity.x > 0)
        {
            dirVec = new Vector3(1, 0, 0);
            prevVec = dirVec;
        }
        else if (rigid.velocity.x < 0)
        {
            dirVec = new Vector3(-1, 0, 0);
            prevVec = dirVec;
        }
        else if (rigid.velocity.y > 0)
        {
            dirVec = new Vector3(0, 1, 0);
            prevVec = dirVec;
        }
        else
        {
            dirVec = new Vector3(0, -1, 0);
            prevVec = dirVec;
        }
        return dirVec;
    }

    void PlayerRaycast()
    {
        dirVec = PlayerDirection();
        Vector3 vec = rigid.position;
        vec.y -= 0.4f;
        Debug.DrawRay(vec, dirVec.normalized * 0.7f, new Color(0, 1, 0));
        RaycastHit2D hit = Physics2D.Raycast(vec, dirVec.normalized, 0.7f, 1 << 3);
        if(hit.collider != null)
        {
            scanObject = hit.collider.gameObject;
        }
        else
        {
            scanObject = null;
        }
    }
}
