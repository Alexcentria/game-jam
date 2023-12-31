using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovements : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 2f;
    private bool enemyLeft = true;
    private PlayerController c;
    private Rigidbody2D rb;
    private Vector2 movement; // equal to target direction
    private PlayerAwarenessControl _playerAwarenessControl;
    private GameObject g;

    // Start is called before the first frame update
    private void Awake()
    {
        g = GameObject.Find("Player");
        rb = this.GetComponent<Rigidbody2D>();
        _playerAwarenessControl = GetComponent<PlayerAwarenessControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerAwarenessControl.AwareOfPlayer)
        {
            //Track player
            Vector3 direction = player.position - transform.position;

            // //Tracks rotation 
            // float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            // rb.rotation = angle;

            //Movement variables
            direction.Normalize();
            movement = direction;

        }
    }

    private void FixedUpdate()
    {
        c = g.GetComponent<PlayerController>();
        if (_playerAwarenessControl.AwareOfPlayer) {
            if (c.facingLeft && !enemyLeft)
            {
                Flip();
            }
            else if (!c.facingLeft && enemyLeft)
            {
                Flip();
            }
        }
        if (_playerAwarenessControl.AwareOfPlayer)
        {
            moveCharater(movement);
        }
        // keep player in-bounds on y-axis
        if (transform.position.y >= 35.7f || transform.position.y <= -35.7f)
        {
            // do nothing
        }
        // keep player in-bounds on x-axis
        else if (transform.position.x >= 120.5f || transform.position.x <= -120.5f)
        {
            // do nothing
        }
    }

    void moveCharater(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        enemyLeft = !enemyLeft;
    }
}
