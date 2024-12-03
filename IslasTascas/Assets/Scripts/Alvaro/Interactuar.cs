using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactuar : MonoBehaviour
{
    public GameObject LetraInteraccion;
    bool interact = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LetraInteraccion.SetActive(true);
            interact = true;
            
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        LetraInteraccion.SetActive(false);
        interact = false;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interact)
        {
            SceneManager.LoadScene("Carta");
        }

    }
}
