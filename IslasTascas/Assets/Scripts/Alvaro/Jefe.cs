using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Jefe : MonoBehaviour
{
    public AIPath aipath;
    public Animator animatorPiernas;
    public Animator animatorTorso;
    public Rigidbody2D rb;
    private Vector2 ultimaDireccion = Vector2.down;

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
        if (rb.velocity.x != 0 || rb.velocity.y != 0)
        {
            ultimaDireccion = new Vector2(rb.velocity.x, rb.velocity.y).normalized;
        }
    }
    private void Animations()
    {

        bool isMoving = rb.velocity.x != 0 || rb.velocity.y != 0;

        if (isMoving)
        {
            if (Mathf.Abs(rb.velocity.x) > Mathf.Abs(rb.velocity.y))
            {
                if (rb.velocity.x > 0)
                {
                    //flipder
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                    PlayAnimation("Mov_Sup_Izq", "Mov_Izq_Inf_Zombie");
                }
                else
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;

                    PlayAnimation("Mov_Sup_Izq", "Mov_Izq_Inf_Zombie");
                }
            }
            else
            {
                if (rb.velocity.y > 0)
                {
                    PlayAnimation("Mov_Sup_Trasero", "Mov_Inf_Trasero");
                }
                else
                {
                    PlayAnimation("Mov_Frontal_Jefe", "Mov_Frontal_Inf_Esbirro");
                }
            }
        }
    }
    private void PlayAnimation(string piernasAnim, string torsoAnim)
    {
        animatorPiernas.Play(piernasAnim);
        animatorTorso.Play(torsoAnim);
    }

    public void AnimaAttake()
    {

        // Animaciones de ataque seg�n la �ltima direcci�n
        if (Mathf.Abs(ultimaDireccion.x) > Mathf.Abs(ultimaDireccion.y))
        {
            if (ultimaDireccion.x > 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                animatorTorso.Play("Ataque_Sup_Izq");
            }
            else
            {
                animatorTorso.Play("Ataque_Sup_Izq");
            }
        }
        else
        {
            if (ultimaDireccion.y > 0)
            {
                animatorTorso.Play("Ataque_Sup_Trasero");
            }
            else
            {
                animatorTorso.Play("Ataque_Frontal_Sup_Jefe");
            }
            
        }
    }
}
      
