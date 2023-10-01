using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCollision : MonoBehaviour
{

    public AudioSource audioPlayer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            audioPlayer.Play();
        }
    } 
}
