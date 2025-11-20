using Unity.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D theRB;

    void Update()
    {
        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal")*movementSpeed, Input.GetAxisRaw("Vertical")*movementSpeed);

        if (Mathf.Abs(theRB.velocity.x) > .01f && Mathf.Abs(theRB.velocity.y) > .01f)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, 0f);
        }

        if(theRB.velocity.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        if(theRB.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f,1f);
        }
    }

}

 