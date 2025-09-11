using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class PlayerController : MovingController
{
    GameState playerTurn;
    public GameManager gameManager;
    private bool canAct = true;

    public bool CanAct
    {
        get { return this.canAct; }
        set { canAct = value; }
    }

    //bool onStairs = false;

    public override void MoveToLeft()
    {
        if (canAct)
        {
            base.MoveToLeft();
            gameManager.SetGameState(GameState.PlayerTurn);
        }
    }
    public override void MoveToRight()
    {
        if (canAct)
        {
            base.MoveToRight();
            gameManager.SetGameState(GameState.PlayerTurn);
        }
    }
    public override void MoveToUp()
    {
        if (canAct)
        {
            base.MoveToUp();

            gameManager.SetGameState(GameState.PlayerTurn);
        }
    }
    public override void MoveToDown()
    {
        if (canAct)
        {
            base.MoveToDown();
            gameManager.SetGameState(GameState.PlayerTurn);
        }
    }
    public override void MoveToUpperRight()
    {
        if (canAct)
        {
            base.MoveToUpperRight();
            gameManager.SetGameState(GameState.PlayerTurn);
        }
    }
    public override void MoveToUpperLeft()
    {
        if (canAct)
        {
            base.MoveToUpperLeft();
            gameManager.SetGameState(GameState.PlayerTurn);
        }
    }
    public override void MoveToLowerRight()
    {
        if (canAct)
        {
            base.MoveToLowerRight();
            gameManager.SetGameState(GameState.PlayerTurn);
        }
    }
    public override void MoveToLowerLeft()
    {
        if (canAct)
        {
            base.MoveToLowerLeft();
            gameManager.SetGameState(GameState.PlayerTurn);
        }
    }
    public override void Wait()
    {
        if (canAct)
        {
            base.Wait();
            gameManager.SetGameState(GameState.PlayerTurn);
        }
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
        canAct = true;
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
