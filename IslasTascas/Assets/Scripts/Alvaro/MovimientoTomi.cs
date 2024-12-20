using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MovimientoTomi : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidad = 5f;
    public Rigidbody2D rb;

    [Header("Animación")]
    public Animator animatorPiernas;
    public Animator animatorTorso;

    private float moveX, moveY;
    private Vector2 ultimaDireccion = Vector2.down;

    [Header("Ataques")]
    public float tiempoA = 0.5f;
    public float tiempoS = 0.5f;
    private bool canAttack = true;
    private bool canShot = true;

    [Header("Disparo")]
    public GameObject proyectilPrefab;
    public float velocidadDisparo = 5f;

    [Header("Daño y gestión")]
    public int damage = 10;
    private Manager gm;

    void Start()
    {
        gm = GameObject.FindWithTag("GM").GetComponent<Manager>();
    }

    void Update()
    {
        Movement();
        Animations();
        Acciones();
    }

    private void Movement()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(moveX, moveY).normalized * velocidad * Time.deltaTime;

        if (moveX != 0 || moveY != 0)
        {
            ultimaDireccion = new Vector2(moveX, moveY).normalized;
        }
    }

    private void Animations()
    {
        bool isMoving = moveX != 0 || moveY != 0;

        if (isMoving)
        {
            if (Mathf.Abs(moveX) > Mathf.Abs(moveY))
            {
                if (moveX > 0)
                {
                    PlayAnimation("WalkRight", "WalkRight");
                }
                else
                {
                    PlayAnimation("WalkLeft", "WalkLeft");
                }
            }
            else
            {
                if (moveY > 0)
                {
                    PlayAnimation("WalkUp", "WalkUp");
                }
                else
                {
                    PlayAnimation("WalkDown", "WalkDown");
                }
            }
        }
        else
        {
            if (ultimaDireccion == Vector2.up)
            {
                PlayAnimation("IdleUp", "IdleUp");
            }
            else if (ultimaDireccion == Vector2.down)
            {
                PlayAnimation("IdleDown", "IdleDown");
            }
            else if (ultimaDireccion == Vector2.left)
            {
                PlayAnimation("IdleLeft", "IdleLeft");
            }
            else if (ultimaDireccion == Vector2.right)
            {
                PlayAnimation("IdleRight", "IdleRight");
            }
        }
    }

    private void PlayAnimation(string piernasAnim, string torsoAnim)
    {
        animatorPiernas.Play(piernasAnim);
        animatorTorso.Play(torsoAnim);
    }

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

    private void RealizarAtaque()
    {
        animatorTorso.Play("Attack");
        canAttack = false;
        Invoke(nameof(ResetAttack), tiempoA);
    }

    private void RealizarDisparo()
    {
        Vector3 posicionRaton = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        posicionRaton.z = 0;
        Vector2 direccionDisparo = (posicionRaton - transform.position).normalized;

        GameObject proyectil = Instantiate(proyectilPrefab, transform.position, Quaternion.identity);
        proyectil.GetComponent<Rigidbody2D>().velocity = direccionDisparo * velocidadDisparo;

        animatorTorso.Play("Shoot");
        canShot = false;
        Invoke(nameof(ResetShot), tiempoS);
    }

    private void ResetAttack()
    {
        canAttack = true;
    }

    private void ResetShot()
    {
        canShot = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
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
