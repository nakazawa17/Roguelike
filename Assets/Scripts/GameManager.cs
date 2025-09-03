using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    PlayerAct,
    PlayerTurn,
    EnemyTurn,
    TurnEnd
}

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    // public GameObject[] EnemyList;
    public GameState currentState;
    public float TurnDelay = 0.5f;

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
            case GameState.PlayerAct:
                break;

            case GameState.PlayerTurn:
                StartCoroutine("PlayerTurn");
                break;

            case GameState.EnemyTurn:
                StartCoroutine("EnemyTurn");
                break;

            case GameState.TurnEnd:
                SetGameState(GameState.PlayerAct);
                break;
        }
    }

    IEnumerator PlayerTurn()
    {
        yield return new WaitForSeconds(TurnDelay);
        SetGameState(GameState.EnemyTurn);
    }

    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(TurnDelay);
        SetGameState(GameState.TurnEnd);
    }
}
