using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puerta : MonoBehaviour
{
    public int enemigosRestantes = 1; // Número de enemigos a derrotar
    public string escenaADesbloquear;

    private void OnEnable()
    {
        Enemy.OnEnemigoDestruido += ReducirEnemigosRestantes;
    }

    private void OnDisable()
    {
        Enemy.OnEnemigoDestruido -= ReducirEnemigosRestantes;
    }

    private void ReducirEnemigosRestantes()
    {
        enemigosRestantes--;

        if (enemigosRestantes <= 0)
        {
            ActivarPuerta();
        }
    }

    private void ActivarPuerta()
    {
        Debug.Log("Puerta activada. Ahora puedes usarla.");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (enemigosRestantes <= 0)
            {
                Debug.Log("Cargando escena: " + escenaADesbloquear);
                SceneManager.LoadScene(escenaADesbloquear);
            }
            else
            {
                Debug.Log($"La puerta está cerrada. Derrota a los {enemigosRestantes} enemigos restantes.");
            }
        }
    }
}
