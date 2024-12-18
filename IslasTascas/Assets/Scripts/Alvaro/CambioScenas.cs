using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioScenas : MonoBehaviour
{
    public string EscenaCambio;
    public bool abierto = true;
    public void CambiarTrigger()
    {
        SceneManager.LoadScene(EscenaCambio);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CambiarTrigger();
        }
    }

    public void CambiarCanvas(string EscenaCambioCanvas)
    {
        SceneManager.LoadScene(EscenaCambioCanvas);
    }

    public void Cerrar()
    {
        Application.Quit();
    }
}
