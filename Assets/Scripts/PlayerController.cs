using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MovingController
{
    GameState playerState;
    GameManager gameManager;
    bool isMoving = false;

    public override void MoveToLeft()
    {
        base.MoveToLeft();
        isMoving = true;
    }
    public override void MoveToRight()
    {
        base.MoveToRight();
        isMoving = true;
    }
    public override void MoveToUp()
    {
        base.MoveToUp();
        isMoving = true;
    }
    public override void MoveToDown()
    {
        base.MoveToDown();
        isMoving = true;
    }
    public override void MoveToUpperRight()
    {
        base.MoveToUpperRight();
        isMoving = true;
    }
    public override void MoveToUpperLeft()
    {
        base.MoveToUpperLeft();
        isMoving = true;
    }
    public override void MoveToLowerRight()
    {
        base.MoveToLowerRight();
        isMoving = true;
    }
    public override void MoveToLowerLeft()
    {
        base.MoveToLowerLeft();
        isMoving = true;
    }
    public override void Wait()
    {
        base.Wait();
        isMoving = true;
    }



    void Update()
    {
        if (isMoving)
        {
            MoveJudge(newPosition);
            if (!cannotMove)
            {
                StartCoroutine(MoveToNewPosition(newPosition));
                newPosition = Vector3.zero;
                isMoving = false;
                cannotMove = true;
                gameManager.GetComponent<GameManager>().SetGameState(GameState.PlayerTurn);
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
