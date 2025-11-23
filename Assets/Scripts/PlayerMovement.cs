using System.Collections;
using Unity.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D theRB;
    public bool canMove = true;
    public Animator anim;

    void FixedUpdate()
    {
        if (!canMove)
        {
            theRB.linearVelocity = Vector2.zero;
            return;   
        }

        theRB.linearVelocity = new Vector2(Input.GetAxisRaw("Horizontal")*movementSpeed, Input.GetAxisRaw("Vertical")*movementSpeed);

        if (Mathf.Abs(theRB.linearVelocity.x) > .01f && Mathf.Abs(theRB.linearVelocity.y) > .01f)
        {
            theRB.linearVelocity = new Vector2(theRB.linearVelocity.x, 0f);
        }

        if(theRB.linearVelocity.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        if(theRB.linearVelocity.x < 0)
        { 
            transform.localScale = new Vector3(-1f, 1f,1f);
        }
        anim.SetFloat("speed", Mathf.Abs(theRB.linearVelocity.x));
        anim.SetFloat("yspeed",Input.GetAxisRaw("Vertical"));

    }

    public IEnumerator DisableMovement(float duration)
    {
        canMove = false;
        yield return new WaitForSeconds(duration);
        canMove = true;
    }
}

 