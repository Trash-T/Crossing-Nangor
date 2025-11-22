using Unity.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D theRB;

    void FixedUpdate()
    {
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
    }

}

 