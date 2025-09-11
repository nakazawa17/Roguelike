using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;


public class MapController : MonoBehaviour
{
    public PlayerController player;
    public StairsController stairs;

    public GameObject[] roomTilemaps;
    private System.Random r = new System.Random();
    public List<Vector3> tileLocations;
    public int stageCount;

    void Awake()
    {
        roomTilemaps = GameObject.FindGameObjectsWithTag("Room");
    }

    public class Count
    {
        public int minEnemy;
        public int maxEnemy;
    }

    public void placeObject()
    {
        Vector3 playerPlace = assign();
        player.transform.position = playerPlace;

        Vector3 stairsPlace = assign();
        stairs.transform.position = stairsPlace;

    }

    public Vector3 assign()
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
}
