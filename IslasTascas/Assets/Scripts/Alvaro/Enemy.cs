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

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Area")
        {
            TakeDamage(20);
            canHurt = false;
            Invoke("EsperaDaño",tiempoD);
        }
        if(collision.gameObject.tag == "Botella")
        {
            TakeDamage(30);
            canHurt = false;
            Invoke("EsperaDaño", tiempoD);
        }
    }
    public void EsperaDaño()
    {
        canHurt = true;
    }
}