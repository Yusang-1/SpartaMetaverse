using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting.APIUpdating;

public class GS1Player : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator animator;
    Collider2D _collider;
    [SerializeField] float speed;
    [SerializeField] float jumpPower;
    [SerializeField] float min;
    [SerializeField] float max;
    public bool isDie { get; private set; }
    public int score { get; private set; }
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        _collider = gameObject.GetComponent<Collider2D>();
        isDie = false;
    }

    private void Update()
    {
        Move();

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        animator.SetFloat("Vel", rigid.velocity.y);

        if(transform.position.y < -5.4f)
        {
            PlayerDie();
        }
    }

    void Move()
    {
        Vector2 vec = rigid.velocity;
        vec.x = speed;

        rigid.velocity = vec;
    }
    void Jump()
    {
        if (isDie) return;
        Vector2 vec = rigid.velocity;
        vec.y += jumpPower;
        vec.y = Mathf.Clamp(vec.y, min, max);

        rigid.velocity = vec;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Triggerable2")
        {
            score++;            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerDie();
    }

    void PlayerDie()
    {
        isDie = true;
        _collider.isTrigger = true;
        animator.SetBool("isDie", true);
        Invoke("Return", 3f);
    }

    void Return()
    {
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
    }
}
