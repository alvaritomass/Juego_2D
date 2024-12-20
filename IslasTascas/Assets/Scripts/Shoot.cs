using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float tiempoDeVida = 5f; // Tiempo antes de que el proyectil se destruya
    public int damage = 10; // Daño que inflige el proyectil

    private void Start()
    {
        // Destruir el proyectil automáticamente después de un tiempo
        Destroy(gameObject, tiempoDeVida);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar colisión con enemigos
        if (other.CompareTag("Borraxo") || other.CompareTag("Boss"))
        {
            // Lógica para infligir daño al enemigo
            Enemy enemigo = other.GetComponent<Enemy>();
            if (enemigo != null)
            {
                enemigo.TakeDamage(damage);
            }

            // Destruir el proyectil después del impacto
            Destroy(gameObject);
        }
        
    }
}
