using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MovimientoTomi : MonoBehaviour
{
    //ORDENAMOS LAS VARIABLES
    [Header("Movimiento")]
    public float velocidad = 5f;
    public Rigidbody2D rb;

    [Header("Animacion")]
    private Animator animator;
    private float moveX, moveY;

    [Header("Ataques")]
    public float tiempoA = 0.5f;
    public float tiempoS = 0.5f;
    private bool canAttack = true;
    private bool canShot = true;

    [Header("Daño y gestión")]
    public int damage = 10;
    private Manager gm;

    //CREAMOS LAS VARIABLES NECESARIAS PARA EL DISPARO
    [Header("Disparo")]
    public GameObject puntoDisparo;
    public GameObject proyectilPrefab;
    public Transform origenDisparo;
    public float velocidadDisparo = 5f;
    private Vector2 ultimaDireccion = Vector2.right;


    void Start()
    {
        animator = GetComponent<Animator>();
        gm = GameObject.FindWithTag("GM").GetComponent<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Animations();
        UpdatePuntoDisparo();
        Acciones();
       
    }

    private void Movement()
    {
        //QUITAMOS EL ATAQUE Y DISPARO DEL MOVIMIENTO
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(moveX, moveY).normalized * velocidad * Time.deltaTime;
        
        /*if (Input.GetMouseButtonDown(0))
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
        }*/
    }

    //Animaciones asociadas al movimiento y a los bool del animator
    private void Animations()
    {
        animator.SetFloat("Horizontal",moveX);
        animator.SetFloat("Vertical", moveY);
        //EL CODIGO SE PUEDE SIMPLIFICAR DE LA SIGUIENTE MANERA
        /*if (moveY !=0)
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
        }*/

        bool isMoving = moveX != 0 || moveY != 0;
        animator.SetBool("isWalking", isMoving);

        //HACEMOS QUE EL GIRO VAYA EN FUNCION DE LA ESCALA Y NO EL FLIP
        Vector3 escala = transform.localScale;
        if (moveX < 0)
        {
            escala.x = -Mathf.Abs(escala.x);
        }
        else if (moveX > 0)
        {
            escala.x = Mathf.Abs(escala.x);
        }
        transform.localScale = escala;

    }

    //AÑADIMOS UNA FUNCIÓN PARA SEPARAR EL MOVIMIENTO DE LAS ACCIONES
    private void Acciones()
    {
        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            RealizarAtaque();
        }

        if (Input.GetMouseButtonDown(1) && canShot)
        {
            RealizarDisparo();
        }
    }

    //AÑADIMOS LAS FUNCIONES QUE LLAMAREMOS EN EN ACCIONES

    private void RealizarAtaque()
    {
        animator.SetBool("isAttacking", true);
        Invoke(nameof(EndAnim), 0.5f);
        canAttack = false;
        Debug.Log("Zasca");
        Invoke(nameof(EsperaAtaque), tiempoA);
    }

    private void RealizarDisparo()
    {
        animator.SetBool("isShooting", true);
        Invoke(nameof(EndAnim), 0.5f);
        canShot = false;
        Debug.Log("Pium");
        //AÑADIMOS EL DISPARO
        GameObject proyectil = Instantiate(proyectilPrefab, origenDisparo.position, Quaternion.identity);

        Vector2 direccionShot = new Vector2(Mathf.Round(moveX), Mathf.Round(moveY));
        if(direccionShot == Vector2.zero)
        {
            direccionShot = transform.localScale.x > 0 ? Vector2.left : Vector2.right;
        }

        proyectil.GetComponent<Rigidbody2D>().velocity = direccionShot.normalized * velocidadDisparo;
        Invoke(nameof(EsperaShot), tiempoS);

    }

    private void UpdatePuntoDisparo()
    {
        Vector2 direccionActual = new Vector2(moveX, moveY);

       
        if (direccionActual != Vector2.zero)
        {
            ultimaDireccion = direccionActual.normalized;
        }

        Vector2 posicionOffset = Vector2.zero;

        
        if (Mathf.Abs(ultimaDireccion.x) > Mathf.Abs(ultimaDireccion.y))
        {
            if (ultimaDireccion.x > 0) 
            {
                posicionOffset = new Vector2(0.5f, 0); 
            }
            else if (ultimaDireccion.x < 0) 
            {
                posicionOffset = new Vector2(-0.5f, 0); 
            }
        }
        else
        {
            if (ultimaDireccion.y > 0) 
            {
                posicionOffset = new Vector2(0, 0.5f); 
            }
            else if (ultimaDireccion.y < 0) 
            {
                posicionOffset = new Vector2(0, -0.5f); 
            }
        }

        if (puntoDisparo != null)
        {
            puntoDisparo.transform.localPosition = posicionOffset;
        }
    }
    private void EndAnim()
    {
        animator.SetBool("isAttacking", false);
        animator.SetBool("isShooting", false);
    }

    public void EsperaAtaque()
    {
        canAttack = true;
    }
    public void EsperaShot()
    {
        canShot = true;
    }

    //PONEMOS EL ONCOLLISION ABAJO PORQUE ME DA GUSTITO EN EL CEREBRO
    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.gameObject.tag == "Borraxo")
        {
            collision.gameObject.GetComponent<Enemy>().AnimaAttake();
            gm.PerderVida();
        }

        if (collision.gameObject.tag == "Beer")
        {
            gm.GanarVida();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Boss")
        {
            collision.gameObject.GetComponent<Boss>().AnimaAttake();
            gm.PerderVida();
        }*/
        
        //PODEMOS CONSEGUIR LO MISMO CON UN SWITCH, AMBOS ESTAN BIEN PERO ESTO ES OTRA FORMA
        switch (collision.gameObject.tag)
        {
            case "Borraxo":
                collision.gameObject.GetComponent<Enemy>().AnimaAttake();
                gm.PerderVida();
                break;

            case "Beer":
                gm.GanarVida();
                Destroy(collision.gameObject);
                break;

            case "Boss":
                collision.gameObject.GetComponent<Boss>().AnimaAttake();
                gm.PerderVida();
                break;
        }
    }
}
