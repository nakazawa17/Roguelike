using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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
    public EnemyManager enemyManager;


    public GameState currentState;
    public int stageCount;

    public float TurnDelay = 0.5f;
    public float EnemyDelay = 1f;

    [SerializeField] int initialEnemyCount;
    [SerializeField] StairsController stairs;
    [SerializeField] GameObject cover;





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
        StartCoroutine("MapUpdata");
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
                StartCoroutine("MapUpdata");
                break;
            case GameState.PlayerWait:

                break;

            case GameState.PlayerTurn:
                cover.SetActive(true);
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
                if (player.transform.position == stairs.transform.position)
                {
                    SetGameState(GameState.MapUpdata);
                }
                else
                {
                    SetGameState(GameState.PlayerWait);
                    player.CanAct = true;
                    cover.SetActive(false);
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
        int enemyCount = enemyManager.enemyList.Count;
        for (int i = 0; i < enemyCount; i++)
        {
            if (enemyManager.enemyList[0])
            {
                yield return new WaitForSeconds(TurnDelay);
            }
            else
            {
                yield return new WaitForSeconds(EnemyDelay);
            }
            enemyManager.enemyList[i].GetComponent<EnemyActController>().StartCoroutine("EnemyAct");

            if (i == enemyCount - 1)
            {
                EnemyActController lastEnemy = enemyManager.enemyList[i - 1].GetComponent<EnemyActController>();
                yield return new WaitUntil(lastEnemy.IsItMoved);
                SetGameState(GameState.TurnEnd);

            }
        }

    }

    IEnumerator MapUpdata()
    {
        uIManager.BlackOut(stageCount);
        stageCount++;

        if (enemyManager.enemyList.Count > 0)
        {
            for (int i = 0; i < initialEnemyCount; i++)
            {
                Destroy(enemyManager.enemyList[i]);
            }
            enemyManager.enemyList.Clear();
        }
        yield return new WaitForSeconds(1.5f);
        mapController.MapChange();

        for (int i = 0; i < initialEnemyCount; i++)
        {
            enemyManager.SpawnEnemy();
        }

        yield return new WaitForSeconds(1.0f);
        SetGameState(GameState.PlayerWait);
        player.CanAct = true;
    }
}
