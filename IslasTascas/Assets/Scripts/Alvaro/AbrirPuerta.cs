using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPuerta : MonoBehaviour
{
    public GameObject llave;
    public GameObject puerta;
    public GameObject salida;


    private void Update()
    {
        if (llave == null)
        {
            puerta.SetActive(false);
            salida.SetActive(true);
        }
        else
        {
            puerta.SetActive(true);
            salida.SetActive(false);

        }
    }
}
