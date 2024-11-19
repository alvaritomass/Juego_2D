using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaTomi : MonoBehaviour
{
    public GameObject[] vidas;
    //private int vida = 4;


    public void DesactivarVida(int indice)
    {
        vidas[indice].SetActive(false);
    }

    public void ActivarVida(int indice)
    {
        vidas[indice].SetActive(true);
    }
}
