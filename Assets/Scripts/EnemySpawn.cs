using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] float spawnTime;
    [SerializeField] GameObject enemyprefabs;

    private void OnEnable()
    {
        StartCoroutine(SpawnRoutin());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
    IEnumerator SpawnRoutin()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            Instantiate(enemyprefabs, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
