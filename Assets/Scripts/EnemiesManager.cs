using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField] MapController mapController;
    [SerializeField] GameObject enemyPrefab;

    [SerializeField] Transform parentTransform;


    [SerializeField] int aboutSpawnTime;
    [SerializeField] const int MAX_ENEMY_COUNT = 10;

    public List<GameObject> enemyList = new List<GameObject>();
    public int initialEnemyCount;



    System.Random r = new System.Random();

    // Start is called before the first frame update
    void Start()
    {

    }

    public bool SpawanTimeEvent(int turnCount)
    {
        bool isSpawn = false;
        if (enemyList.Count > MAX_ENEMY_COUNT)
        {
            return isSpawn = true;
        }
        int randomValue = r.Next(10) + 1;

        if (turnCount > (aboutSpawnTime + randomValue))
        {
            SpawnEnemy();
            isSpawn = true;
        }
        return isSpawn;
    }

    public void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity, parentTransform);
        mapController.AssignEnemy(enemy);
        enemyList.Add(enemy);
    }
}
