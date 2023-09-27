using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D body;

    public float horizontal;
    public float vertical;
    public float slowDiagonal = 0.7f;

    public float moveSpeed = 0.5f;
    public bool facingLeft = true;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        // check for diagonal movement and slow it down
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= slowDiagonal;
            vertical *= slowDiagonal;
        }

        // keep player in-bounds on y-axis
        if (transform.position.y >= 35.2f)
        {
            transform.position = new Vector3(transform.position.x, 35.5f, 0);
        }
        else if (transform.position.y <= -35.2f)
        {
            transform.position = new Vector3(transform.position.x, -35.5f, 0);
        }

        // keep player in-bounds on x-axis
        if (transform.position.x >= 120.7f)
        {
            transform.position = new Vector3(120.5f, transform.position.y, 0);
        }
        else if (transform.position.x <= -120.7f)
        {
            transform.position = new Vector3(-120.5f, transform.position.y, 0);
        }

        body.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);

        if (horizontal > 0 && facingLeft)
        {
            Flip();
        }
        else if (horizontal < 0 && !facingLeft)
        {
            Flip();
        }
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingLeft = !facingLeft;
    }
}
