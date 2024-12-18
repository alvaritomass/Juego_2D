using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    private int vidas = 4;
    public VidaTomi hud;




    public void PerderVida()
    {
        if (vidas > 0)
        {
            hud.DesactivarVida(vidas);
            vidas -= 1;
        }
        else
        {
            hud.DesactivarVida(vidas);
            SceneManager.LoadScene("Muerte");
            //animacion muerte
        }

    }
    
    public void GanarVida()
    {
        if (vidas < 5)
        {
            vidas += 1;
            hud.ActivarVida(vidas);
        }
        
    }
}
