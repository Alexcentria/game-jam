using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovements : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 2f;
    private Rigidbody2D rb;
    private Vector2 movement; // equal to target direction
    private PlayerAwarenessControl _playerAwarenessControl;


    // Start is called before the first frame update
    private void Awake()
    {
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

            //Tracks rotation 
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;

            //Movement variables
            direction.Normalize();
            movement = direction;

        }
    }
    private void FixedUpdate()
    {
        moveCharater(movement);
    }
    void moveCharater(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
