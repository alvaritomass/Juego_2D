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
    public float tiempoA = 0.5f;
    public float tiempoS = 0.5f;
    bool canAttack = true;
    bool canShot = true;
    public int damage = 10;
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
            if (canAttack)
            {
                //animator.Play("AtaqueNinja");
                animator.SetBool("isAttacking", true);
                Invoke("EndAnim", 0.5f);
                canAttack = false;
                Invoke("EsperaAtaque", tiempoA);
            }

        }
         if (Input.GetMouseButtonDown(1))
        {

            if (canShot)
            {
                animator.SetBool("isShooting", true);
                Invoke("EndAnim", 0.5f);
                canShot = false;
                Invoke("EsperaShot", tiempoS);

            }
        }
    }
    private void EndAnim()
    {
        animator.SetBool("isAttacking", false);
        animator.SetBool("isShooting", false) ;
    }

    //Animaciones asociadas al movimiento y a los bool del animator
    private void Animations()
    {
        animator.SetFloat("Horizontal",moveX);
        animator.SetFloat("Vertical", moveY);
        if (moveY !=0)
        {
            //animator.Play("MovimientoStick");
            animator.SetBool("isWalking", true);

        }
        if (moveX !=0)
        {
            //animator.Play("MovimientoStick");
            animator.SetBool("isWalking", true);


            if (moveX < 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                //gameObject.transform.localScale = 
            }
            else if (moveX > 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;

            }
        }
        else
        {
            animator.SetBool("isWalking", false);

            //animator.Play("Quieto");
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Borraxo")
        {
            collision.gameObject.GetComponent<Enemy>().AnimaAttake();
        }
    }
    public void EsperaAtaque()
    {
        canAttack = true;
    }
    public void EsperaShot()
    {
        canShot = true;
    }

}
