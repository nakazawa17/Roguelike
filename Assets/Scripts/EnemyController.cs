using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PositionRelation
{
    Right,
    Left,
    Up,
    Down,
    UpperRight,
    UpperLeft,
    LowerRight,
    LowerLeft
}

public class EnemyController : MovingController
{
    private PlayerController player;
    private Vector2 playerPos;
    public PositionRelation relation;

    public void EnemyAct()
    {
        player = FindFirstObjectByType<PlayerController>();
        playerPos = player.transform.position;
        int Xdir = (int)playerPos.x - (int)this.transform.position.x;
        int Ydir = (int)playerPos.y - (int)this.transform.position.y;

        int AbsXdir = System.Math.Abs(Xdir);
        int AbsYdir = System.Math.Abs(Ydir);

        // if (AbsXdir > 5 || AbsYdir > 5){}
        if (AbsXdir > AbsYdir)
        {
            if (Xdir < 0)
            {
                MoveToLowerRight();
                relation = PositionRelation.Right;
            }
            else if (Xdir > 0)
            {
                MoveToLeft();
                relation = PositionRelation.Left;
            }
        }
        else if (AbsXdir < AbsYdir)
        {
            if (Ydir < 0)
            {
                MoveToUp();
                relation = PositionRelation.Up;
            }
            else
            {
                MoveToDown();
                relation = PositionRelation.Down;
            }
        }
        else if (AbsXdir == AbsYdir)
        {
            if (Xdir < 0 && Ydir < 0)
            {
                MoveToUpperRight();
                relation = PositionRelation.UpperRight;
            }
            else if (Xdir > 0 && Ydir < 0)
            {
                MoveToUpperLeft();
                relation = PositionRelation.UpperLeft;
            }
            else if (Xdir < 0 && Ydir > 0)
            {
                MoveToLowerRight();
                relation = PositionRelation.LowerRight;
            }
            else if (Xdir > 0 && Ydir < 0)
            {
                MoveToLowerLeft();
                relation = PositionRelation.LowerLeft;
            }
        }
        MoveJudge(this.newPosition);
        if (cannotMove)
        {
            StartCoroutine(MoveToNewPosition(newPosition));
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
