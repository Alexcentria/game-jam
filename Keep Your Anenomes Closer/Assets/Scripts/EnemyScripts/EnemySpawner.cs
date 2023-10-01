using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    int count = 1;
    int limit = 5;
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
        if (count < limit)
        {
            yield return new WaitForSeconds(interval);
            GameObject newEnemy = Instantiate(enemy, new UnityEngine.Vector3(Random.Range(-3f, 3f), Random.Range(-4f, 4f), 0), UnityEngine.Quaternion.identity);
            StartCoroutine(spawnEnemy(interval, enemy));

            count++;
        }
       
    }
}
