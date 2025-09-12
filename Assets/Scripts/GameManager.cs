using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public enum GameState
{
    MapUpdata,
    PlayerWait,
    PlayerTurn,
    PlayerAction,
    EnemyTurn,
    EnemyAction,
    TurnEnd
}

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public MapController mapController;
    public PlayerController player;
    public UIManager uIManager;
    public EnemiesManager enemiseManager;


    public GameState currentState;
    public int stageCount;


    public int turnCount;
    public bool onStairs;


    [SerializeField] float TurnDelay = 0.3f;
    [SerializeField] float EnemyDelay = 0.2f;




    void Awake()
    {

        if (gameManager == null)
        {
            gameManager = this;
        }
        else if (gameManager != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

    }
    void Start()
    {
        SetGameState(GameState.MapUpdata);
    }
    public void SetGameState(GameState state)
    {
        currentState = state;
        GameStateChange(currentState);
    }

    void GameStateChange(GameState state)
    {
        switch (state)
        {
            case GameState.MapUpdata:
                StartCoroutine("CreateMap");
                break;

            case GameState.PlayerWait:
                break;

            case GameState.PlayerTurn:
                player.CanAct = false;
                StartCoroutine("PlayerTurn");
                break;

            case GameState.PlayerAction:
                SetGameState(GameState.EnemyTurn);
                break;

            case GameState.EnemyTurn:
                SetGameState(GameState.EnemyAction);
                break;

            case GameState.EnemyAction:
                StartCoroutine("EnemyTurn");
                break;

            case GameState.TurnEnd:
                if (onStairs)
                {
                    SetGameState(GameState.MapUpdata);
                }
                else
                {
                    Debug.Log("TurnEnd");
                    SetGameState(GameState.PlayerWait);
                    player.CanAct = true;
                    turnCount++;
                    bool isSpawn = enemiseManager.SpawanTimeEvent(turnCount);
                    if (isSpawn)
                    {
                        turnCount = 0;
                    }
                }
                break;
        }
    }

    IEnumerator PlayerTurn()
    {
        yield return new WaitForSeconds(TurnDelay);
        player.PlayerAct();
    }

    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(TurnDelay);
        int listSize = enemiseManager.enemyList.Count;

        for (int i = 0; i < listSize; i++)
        {
            if (i == 0)
            {
                yield return new WaitForSeconds(TurnDelay);
            }
            else
            {
                yield return new WaitForSeconds(EnemyDelay);
            }
            EnemyActController enemy = enemiseManager.enemyList[i].GetComponent<EnemyActController>();
            enemy.StartCoroutine("EnemyAct");

            if (i == (listSize - 1))
            {
                yield return new WaitUntil(enemy.getIsMoved);
                Debug.Log("i : " + i);
                SetGameState(GameState.TurnEnd);
            }

        }

    }

    IEnumerator CreateMap()
    {
        uIManager.BlackOut(stageCount);
        stageCount++;
        onStairs = false;

        // 初回起動時は処理しない
        if (enemiseManager.enemyList != null)
        {
            foreach (GameObject enemy in enemiseManager.enemyList)
            {
                Destroy(enemy);
            }
        }

        yield return new WaitForSeconds(1.5f);
        mapController.MapChange();

        enemiseManager.enemyList.Clear();
        for (int i = 0; i < enemiseManager.initialEnemyCount; i++)
        {
            enemiseManager.SpawnEnemy();
        }

        yield return new WaitForSeconds(1.0f);
        SetGameState(GameState.PlayerWait);
        player.CanAct = true;
    }
}
