using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MovimientoTomi : MonoBehaviour
{
    
    public float velocidad = 5f;
    float moveY;
    float moveX;
    public Rigidbody2D rb;

    Animator animator;
    bool IsAttacking;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Animations();
    }

    private void Movement()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(moveX, moveY).normalized * velocidad * Time.deltaTime;

        if (Input.GetMouseButtonDown(0)) 
        {
            animator.Play("Ataque");
            IsAttacking = true; 
        }
    }

    private void EndAttack()
    {
        IsAttacking = false;
    }
    private void Animations()
    {
        animator.SetFloat("Horizontal",moveX);
        animator.SetFloat("Vertical", moveY);
        if (moveY !=0)
        {
            animator.Play("MovimientoStick");
        }
        if (moveX !=0)
        {
            animator.Play("MovimientoStick");

            if (moveX < 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (moveX > 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;

            }


        }
        else
        {
            animator.Play("Quieto");
        }
    }
}
