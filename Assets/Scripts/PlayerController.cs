using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MovingController
{
    GameState playerState;
    public GameManager gameManager;
    bool isMoving = false;

    public override void MoveToLeft()
    {
        if (playerState == GameState.PlayerAct)
        {
            base.MoveToLeft();
            isMoving = true;
        }
    }
    public override void MoveToRight()
    {
        if (playerState == GameState.PlayerAct)
        {
            base.MoveToRight();
            isMoving = true;
        }
    }
    public override void MoveToUp()
    {
        if (playerState == GameState.PlayerAct)
        {
            base.MoveToUp();
            isMoving = true;
        }
    }
    public override void MoveToDown()
    {
        if (playerState == GameState.PlayerAct)
        {
            base.MoveToDown();
            isMoving = true;
        }
    }
    public override void MoveToUpperRight()
    {
        if (playerState == GameState.PlayerAct)
        {
            base.MoveToUpperRight();
            isMoving = true;
        }
    }
    public override void MoveToUpperLeft()
    {
        if (gameManager.currentState == GameState.PlayerAct)
        {
            base.MoveToUpperLeft();
            isMoving = true;
        }
    }
    public override void MoveToLowerRight()
    {
        if (gameManager.currentState == GameState.PlayerAct)
        {
            base.MoveToLowerRight();
            isMoving = true;
        }
    }
    public override void MoveToLowerLeft()
    {
        if (gameManager.currentState == GameState.PlayerAct)
        {
            base.MoveToLowerLeft();
            isMoving = true;
        }
    }
    public override void Wait()
    {
        if (gameManager.currentState == GameState.PlayerAct)
        {
            base.Wait();
            isMoving = true;
        }
    }

    void Start()
    {
        gameManager.GetComponent<GameManager>();
    }

    void Update()
    {
        if (isMoving)
        {
            MoveJudge(newPosition);
            if (!cannotMove)
            {
                StartCoroutine(MoveToNewPosition(newPosition));
                isMoving = false;
                cannotMove = true;
                gameManager.SetGameState(GameState.PlayerTurn);
            }

        }



    }

    protected override void MoveJudge(Vector3 newPosition)
    {
        gameManager = FindFirstObjectByType<GameManager>();
        playerState = gameManager.GetComponent<GameManager>().currentState;

        if (playerState == GameState.PlayerAct)
        {
            base.MoveJudge(newPosition);
        }

    }

}
