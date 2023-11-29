using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform player;
    [SerializeField] private float spawnInterval;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(spawnInterval, enemy));
    }

    // Update is called once per frame
    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        Instantiate(enemy, player.position + (new Vector3(Random.Range(-5f, 5), Random.Range(-5f, 5), 0)), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
