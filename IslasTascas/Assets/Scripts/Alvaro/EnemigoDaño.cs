using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoDaño : MonoBehaviour
{
    public float HP = 100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            HP -= 10;
            if (HP < 0)
            {
                Destroy(GameObject);
            }
        }
    }
}

