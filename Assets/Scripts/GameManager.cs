using System.Collections;
using System.Collections.Generic;
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

    public GameObject[] enemyArray;
    public GameState currentState;
    public int stageCount;

    public bool onStairs;

    public float TurnDelay = 0.5f;
    public float EnemyDelay = 1f;




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
                    SetGameState(GameState.PlayerWait);
                    player.CanAct = true;
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
        enemyArray = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < enemyArray.Length; i++)
        {
            if (enemyArray[0])
            {
                yield return new WaitForSeconds(TurnDelay);
            }
            else
            {
                yield return new WaitForSeconds(EnemyDelay);
            }
            enemyArray[i].GetComponent<EnemyActController>().EnemyAct();

        }
        SetGameState(GameState.TurnEnd);
    }

    IEnumerator MapUpdata()
    {
        uIManager.BlackOut(stageCount);
        stageCount++;
        onStairs = false;

        foreach (GameObject enemy in enemyArray)
        {
            Destroy(enemy);
        }

        yield return new WaitForSeconds(1.5f);
        mapController.MapChange();

        yield return new WaitForSeconds(1.0f);
        SetGameState(GameState.PlayerWait);
        player.CanAct = true;
    }
}
