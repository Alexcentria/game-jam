using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (!(collision.gameObject.CompareTag("Player")))
        {
            Destroy(collision.gameObject);
        }
    }
}
