using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    
    private void Awake()
    {
        
    }

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        
        
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector2 vec = new Vector2(horizontal, vertical);
        rigid.velocity = vec;
    }
}
