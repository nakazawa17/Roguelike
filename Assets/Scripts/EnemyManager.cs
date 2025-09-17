using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] MapController mapController;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform parentObj;

    public List<GameObject> enemyList;

    public void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity, parentObj);
        enemyList.Add(enemy);
        mapController.AssignEnemy(enemy);
    }
}
