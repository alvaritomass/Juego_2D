using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Settings")]
    public int health = 100;
    public float damageCooldown = 0.5f;

    [Header("Player Reference")]
    public GameObject player;

    private bool canHurt = true;

    public delegate void EnemigoDestruidoHandler();
    public static event EnemigoDestruidoHandler OnEnemigoDestruido;

    

    private void OnDestroy()
    {
        OnEnemigoDestruido?.Invoke();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void AnimaAttake()
    {
        // Placeholder
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!canHurt) return;

        switch (collision.gameObject.tag)
        {
            case "Area":
                if (Input.GetMouseButton(0))
                {
                    TakeDamage(20);
                    TriggerDamageCooldown();
                }
                break;

            case "Botella":
                TakeDamage(30);
                Debug.Log(health);
                TriggerDamageCooldown();
                break;
        }
    }

    private void TriggerDamageCooldown()
    {
        canHurt = false;
        Invoke(nameof(ResetDamageCooldown), damageCooldown);
    }

    private void ResetDamageCooldown()
    {
        canHurt = true;
    }

}