using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellorFollow : MonoBehaviour
{
    Rigidbody2D body;
    PlayerController c;
    float horizontal;
    float vertical;
    float input;
    bool facingLeft = true;

    void Start()
    {
        // set start position
        transform.position = new Vector3(3.0f, -0.16f, 0);
        // get rigidbody component
        body = GetComponent<Rigidbody2D>();
    }

    void Update () 
    {
        c = GetComponentInParent<PlayerController>();
        input = c.horizontal;
        facingLeft = c.facingLeft;
    }

    void FixedUpdate()
    {
        c = GetComponentInParent<PlayerController>();

        // get the change in position from the parent and add the offset
        if (facingLeft)
        {   
            // slow down diagonal movement
            if (c.horizontal != 0 && c.vertical != 0)
            {
                if (c.vertical > 0){
                    horizontal = transform.parent.position.x + 3.1f;
                    vertical = transform.parent.position.y - 0.35f;
                }
                else {
                    horizontal = transform.parent.position.x + 3.1f;
                    vertical = transform.parent.position.y - 0.11f;
                }
            }
            // 1D motion
            else {
                horizontal = transform.parent.position.x + 3.0f;
                vertical = transform.parent.position.y - 0.23f;
            }
        }
        else if (!facingLeft){
            // slow down diagonal movement
            if (c.horizontal != 0 && c.vertical != 0)
            {
                if (c.vertical > 0){
                    horizontal = transform.parent.position.x - 3.1f;
                    vertical = transform.parent.position.y - 0.35f;
                }
                else {
                    horizontal = transform.parent.position.x - 3.1f;
                    vertical = transform.parent.position.y - 0.11f;
                }
            }
            // 1D motion
            else {
                horizontal = transform.parent.position.x - 3.0f;
                vertical = transform.parent.position.y - 0.23f;
            }
        }

        // update position
        transform.position = new Vector3 (horizontal, vertical, 0);
    
        // update body velocity
        body.velocity = new Vector2(c.horizontal * c.moveSpeed, c.vertical * c.moveSpeed);
    }
}
