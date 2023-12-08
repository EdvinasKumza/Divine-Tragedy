using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform player;
    [SerializeField] private float spawnInterval;
    [SerializeField] private float minDistance; //max 14, for higher adjust random.range in spawnEnemy()
    [SerializeField] private int maxPackSize;
    [SerializeField] private int minPackSize;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(spawnInterval, enemy, Mathf.Min(minDistance,14))); 
    }

    // Update is called once per frame
    private IEnumerator spawnEnemy(float interval, GameObject enemy, float minDistance)
    {
        yield return new WaitForSeconds(interval);
        int enemies = Random.Range(minPackSize, maxPackSize);
        for (int i = 0; i < enemies; i++)
        {
            Vector3 enemySpawnPoint;
            do
            {
                enemySpawnPoint = player.position + new Vector3(Random.Range(-10f, 10), Random.Range(-10f, 10), 0);
            } while (Vector3.Distance(player.position, enemySpawnPoint) < minDistance);

            Instantiate(enemy, enemySpawnPoint, Quaternion.identity);
        }
        StartCoroutine(spawnEnemy(interval, enemy, minDistance));
    }
}
