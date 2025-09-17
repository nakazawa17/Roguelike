using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class PlayerController : MovingController
{
    GameState playerTurn;
    public GameManager gameManager;

    public override void MoveToLeft()
    {
        base.MoveToLeft();
        gameManager.SetGameState(GameState.PlayerTurn);
    }
    public override void MoveToRight()
    {
        base.MoveToRight();
        gameManager.SetGameState(GameState.PlayerTurn);
    }

    public override void MoveToUp()
    {
        base.MoveToUp();
        gameManager.SetGameState(GameState.PlayerTurn);
    }
    public override void MoveToDown()
    {
        base.MoveToDown();
        gameManager.SetGameState(GameState.PlayerTurn);

    }
    public override void MoveToUpperRight()
    {
        base.MoveToUpperRight();
        gameManager.SetGameState(GameState.PlayerTurn);
    }

    public override void MoveToUpperLeft()
    {
        base.MoveToUpperLeft();
        gameManager.SetGameState(GameState.PlayerTurn);
    }

    public override void MoveToLowerRight()
    {
        base.MoveToLowerRight();
        gameManager.SetGameState(GameState.PlayerTurn);
    }

    public override void MoveToLowerLeft()
    {
        base.MoveToLowerLeft();
        gameManager.SetGameState(GameState.PlayerTurn);
    }

    public override void Wait()
    {
        base.Wait();
        gameManager.SetGameState(GameState.PlayerTurn);
    }


    void Start()
    {
        gameManager.GetComponent<GameManager>();
    }

    public void PlayerAct()
    {
        MoveJudge(newPosition);
        if (!cannotMove)
        {
            StartCoroutine(MoveToNewPosition(newPosition));
            newPosition = Vector3.zero;
            cannotMove = true;
            gameManager.SetGameState(GameState.PlayerAction);
        }
        gameManager.SetGameState(GameState.PlayerWait);
        gameManager.cover.SetActive(false);
    }

    protected override void MoveJudge(Vector3 newPosition)
    {
        gameManager = FindFirstObjectByType<GameManager>();
        playerTurn = gameManager.GetComponent<GameManager>().currentState;

        if (playerTurn == GameState.PlayerTurn)
        {
            base.MoveJudge(newPosition);
        }

    }

}
