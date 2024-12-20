using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float tiempoDeVida = 5f; // Tiempo antes de que el proyectil se destruya
    public int damage = 10; // Da�o que inflige el proyectil

    private void Start()
    {
        // Destruir el proyectil autom�ticamente despu�s de un tiempo
        Destroy(gameObject, tiempoDeVida);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar colisi�n con enemigos
        if (other.CompareTag("Borraxo") || other.CompareTag("Boss"))
        {
            // L�gica para infligir da�o al enemigo
            Enemy enemigo = other.GetComponent<Enemy>();
            if (enemigo != null)
            {
                enemigo.TakeDamage(damage);
            }

            // Destruir el proyectil despu�s del impacto
            Destroy(gameObject);
        }
        
    }
}
