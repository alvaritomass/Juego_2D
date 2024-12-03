using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioScenas : MonoBehaviour
{
    public int EscenaCambio;
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

    public void CambiarCanvas(int EscenaCambioCanvas)
    {
        SceneManager.LoadScene(EscenaCambioCanvas);
    }
}
