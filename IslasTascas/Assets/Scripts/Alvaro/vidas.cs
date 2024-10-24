using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidas : MonoBehaviour
{
    public GameObject[] vida;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public void DesactivasVida(int indice)
    {
        vida[indice].SetActive(false);
    }

    public void ActivarVida(int indice)
    {
        vida[indice].SetActive(true);
    }
}
