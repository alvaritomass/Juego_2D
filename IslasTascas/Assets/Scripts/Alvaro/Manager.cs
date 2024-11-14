using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private int vidas = 5;
    public VidaTomi hud;




    public void PerderVida()
    {
        vidas = -1;
        hud.DesactivarVida(vidas);
    }
}
