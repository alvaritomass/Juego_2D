using System.Collections;
using System.Collections.Generic;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
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
}
