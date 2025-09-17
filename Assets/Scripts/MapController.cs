using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;


public class MapController : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] StairsController stairs;
    [SerializeField] GameManager gameManager;
    [SerializeField] UIManager uIManager;
    [SerializeField] EnemyManager enemyManager;


    [SerializeField] GameObject[] stages;
    [SerializeField] GameObject[] roomTilemaps;

    private System.Random r = new System.Random();
    public List<Vector3> tileLocations;

    GameObject currentStage;

    public class Count
    {
        public int minEnemy;
        public int maxEnemy;
    }
    public void MapChange()
    {
        currentStage = GameObject.FindWithTag("Stage");
        currentStage.SetActive(false);
        int randomValue = r.Next(stages.Length);
        currentStage = stages[randomValue];
        currentStage.SetActive(true);
        roomTilemaps = GameObject.FindGameObjectsWithTag("Room");
        PlaceObject();
    }

    private void PlaceObject()
    {
        Vector3 playerPlace = Assign();
        player.transform.position = playerPlace;
        Vector3 stairsPlace = Assign();
        stairs.transform.position = stairsPlace;

    }

    private Vector3 Assign()
    {
        int randomValue = r.Next(roomTilemaps.Length);
        Tilemap assignedRoom = roomTilemaps[randomValue].GetComponent<Tilemap>();
        tileLocations = new List<Vector3>();

        foreach (var pos in assignedRoom.cellBounds.allPositionsWithin)
        {
            Vector3Int localPlace = new Vector3Int(pos.x, pos.y, pos.z);
            Vector3 place = assignedRoom.CellToWorld(localPlace);
            if (assignedRoom.HasTile(localPlace))
            {
                tileLocations.Add(place);
            }
        }
        int randomNum = r.Next(tileLocations.Count);
        Vector3 assignedLocation = tileLocations[randomNum] + new Vector3(0.5f, 0.5f, 0);
        return assignedLocation;
    }

    public void AssignEnemy(GameObject enemy)
    {
        Vector3 assignedLocation = Vector3.zero;
        bool canAssign = false;

        while (!canAssign)
        {
            assignedLocation = Assign();
            Vector3 playerPos = GameObject.FindWithTag("Player").transform.position;
            if (assignedLocation != playerPos)
            {
                canAssign = true;
            }
            /*
            for (int i = 0; i < gameManager.enemyArray.Length; i++)
            {

            }
            */

        }
        enemy.transform.position = assignedLocation;
    }
}
