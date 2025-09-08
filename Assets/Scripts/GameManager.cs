using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public enum GameState
{
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
    public PlayerController player;
    public GameObject[] enemyArray;
    public GameState currentState;

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
            case GameState.PlayerWait:
                Debug.Log(currentState);
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
                SetGameState(GameState.PlayerWait);
                player.CanAct = true;
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
            enemyArray[i].GetComponent<EnemyController>().EnemyAct();

        }
        SetGameState(GameState.TurnEnd);
    }
}
