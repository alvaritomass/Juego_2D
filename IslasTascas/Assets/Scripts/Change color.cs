using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changecolor : MonoBehaviour
{
    public float intervalo = 1f;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
     
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            return;
        }

        InvokeRepeating(nameof(ChangeColor), 0f, intervalo);
    }

    void ChangeColor()
    {
        if (spriteRenderer != null)
        {
            Color randomColor = new Color(
                Random.Range(0f, 1f), 
                Random.Range(0f, 1f), 
                Random.Range(0f, 1f) 
            );           
            spriteRenderer.color = randomColor;
        }
    }
}
