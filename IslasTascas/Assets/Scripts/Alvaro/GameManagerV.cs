using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerV : MonoBehaviour
{

    private int vidas = 3;
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PerderVida()
    {
        vidas -= 1;
        
    }
    
}
