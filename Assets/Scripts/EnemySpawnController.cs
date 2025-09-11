using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] MapController mapController;
    [SerializeField] GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity);
        mapController.Assign(enemy);
    }
}
