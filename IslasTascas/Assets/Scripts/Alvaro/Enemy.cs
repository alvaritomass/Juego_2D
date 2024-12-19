using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 100;
    public GameObject player;
    public float tiempoD = 0.5f;
    bool canHurt = true;
    public void TakeDamage(int damage)
    {
        health = -damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }

    private void Update()
    {
        
    }

    public void AnimaAttake()
    {
        //animacion de enemigo pegando
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //cuando el enemigo entra en las �reas area y botella perdera vida
        if(collision.gameObject.tag == "Area")
        {
            if(Input.GetMouseButton(0))
            {
                TakeDamage(20);
                canHurt = false;
                Invoke("EsperaDa�o", tiempoD);
            }
            
        }
        if(collision.gameObject.tag == "Botella")
        {
            TakeDamage(30);
            canHurt = false;
            Invoke("EsperaDa�o", tiempoD);
        }
    }
    public void EsperaDa�o()
    {
        canHurt = true;
    }

}