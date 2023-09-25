using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerSpin : MonoBehaviour
{
    Rigidbody2D body;
    PlayerController c;
    public float coefficient = 10.0f;
    float velocity;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        c = GetComponentInParent<PlayerController>();
        velocity = c.body.velocity.magnitude;

        body.transform.Rotate(0f, 0f, coefficient * velocity * Time.fixedDeltaTime, Space.Self);
    }
}
