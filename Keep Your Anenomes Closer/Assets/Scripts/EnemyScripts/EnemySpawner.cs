using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // CALL [SerializeField] before components of a prefab (:
    [SerializeField]
    private GameObject basicPrefab;
    [SerializeField]
    private float enemyInterval = 5f; // in seconds, will randomize later
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(enemyInterval, basicPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new UnityEngine.Vector3(Random.Range(-5f, 5f), Random.Range(-6f, 6f), 0), UnityEngine.Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
