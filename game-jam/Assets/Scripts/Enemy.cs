using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // default behavior if not set (should be set!!)
    [SerializeField]
    private int damage = 0;
    [SerializeField]
    private int health = 0;
    [SerializeField]
    private float speed = 0f;

    // 
    [SerializeField]
    private EnemyData data;

    // must target player
    [SerializeField]
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // player = GameObject.findGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Swarm();
    }

    /* private void Swarm()
     * {
     * transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
     * }
     */
}
