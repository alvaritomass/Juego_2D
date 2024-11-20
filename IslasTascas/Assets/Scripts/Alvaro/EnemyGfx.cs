using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyGfx : MonoBehaviour
{
    public AIPath aipath;

    private void Update()
    {
        if (aipath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3 (-1f, 1f, 1f);
        }
        else if (aipath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
