using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class Boss : MonoBehaviour
{
    public Transform target;
    public float speed = 200f;
    public float nextWaypointDistance = 1.2f;

    Path path;
    int currentWayPoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    public Transform graficos;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnpathComplete);
        }
    }
    void OnpathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }
    public void AnimaAttake()
    {
        //animacion de enemigo pegando
    }


    void FixedUpdate()
    {
        if (path == null)
            return;
        if(currentWayPoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }
        Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint]-rb.position).normalized;
        
        Vector2 force = direction * speed* Time.deltaTime;

        rb.AddForce(force);
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);

        if(distance < nextWaypointDistance)
        {
            currentWayPoint++;
        }

        if(rb.velocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (rb.velocity.x <=-0.01f)
        {
             transform.localScale = new Vector3 (1f, 1f, 1f);
        }
    }

}
