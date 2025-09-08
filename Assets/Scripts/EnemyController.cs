using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PositionRelation
{
    RIGHT,
    LEFT,
    UP,
    DOWN,
    UPPER_RIGHT,
    UPPER_LEFT,
    LOWER_RIGHT,
    LOWER_LEFT
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

            if (Xdir > 0)
            {
                MoveToRight();
                relation = PositionRelation.RIGHT;
            }
            else
            {
                MoveToLeft();
                relation = PositionRelation.LEFT;
            }
        }
        else if (AbsXdir < AbsYdir)
        {
            if (Ydir > 0)
            {
                MoveToUp();
                relation = PositionRelation.UP;

            }
            else
            {
                MoveToDown();
                relation = PositionRelation.DOWN;

            }
        }
        else if (AbsXdir == AbsYdir)
        {
            if (Xdir > 0 && Ydir > 0)
            {
                MoveToUpperRight();
                relation = PositionRelation.UPPER_RIGHT;

            }
            else if (Xdir < 0 && Ydir > 0)
            {
                MoveToUpperLeft();
                relation = PositionRelation.UPPER_LEFT;

            }
            else if (Xdir > 0 && Ydir < 0)
            {
                MoveToLowerRight();
                relation = PositionRelation.LOWER_RIGHT;

            }
            else if (Xdir < 0 && Ydir < 0)
            {
                MoveToLowerLeft();
                relation = PositionRelation.LOWER_LEFT;

            }
        }

        MoveJudge(newPosition);
        if (cannotMove)
        {
            AvoidObject(Xdir, Ydir);
        }

        if (!cannotMove)
        {
            StartCoroutine(MoveToNewPosition(newPosition));
        }
        cannotMove = true;
    }
    private void AvoidObject(int Xdir, int Ydir)
    {
        switch (relation)
        {
            case PositionRelation.RIGHT:
                if (cannotMove)
                {
                    MoveToUpperRight();
                    MoveJudge(newPosition);

                }
                if (cannotMove)
                {
                    MoveToLowerRight();
                    MoveJudge(newPosition);
                }
                if (cannotMove)
                {
                    MoveToUp();
                    MoveJudge(newPosition);
                }
                if (cannotMove)
                {
                    MoveToDown();
                    MoveJudge(newPosition);

                }
                if (cannotMove)
                {
                    Wait();
                    MoveJudge(newPosition);
                }
                break;
            case PositionRelation.LEFT:
                if (cannotMove)
                {
                    MoveToUpperLeft();
                    MoveJudge(newPosition);

                }
                if (cannotMove)
                {
                    MoveToLowerLeft();
                    MoveJudge(newPosition);
                }
                if (cannotMove)
                {
                    MoveToUp();
                    MoveJudge(newPosition);
                }
                if (cannotMove)
                {
                    MoveToDown();
                    MoveJudge(newPosition);
                }
                if (cannotMove)
                {
                    Wait();
                    MoveJudge(newPosition);
                }
                break;
            case PositionRelation.UP:
                if (cannotMove)
                {
                    MoveToUpperRight();
                    MoveJudge(newPosition);
                }

                if (cannotMove)
                {
                    MoveToUpperLeft();
                    MoveJudge(newPosition);
                }

                if (cannotMove)
                {
                    MoveToRight();
                    MoveJudge(newPosition);
                }
                if (cannotMove)
                {
                    MoveToLeft();
                    MoveJudge(newPosition);
                }
                if (cannotMove)
                {
                    Wait();
                    MoveJudge(newPosition);
                }
                break;
            case PositionRelation.DOWN:
                if (cannotMove)
                {
                    MoveToLowerRight();
                    MoveJudge(newPosition);
                }

                if (cannotMove)
                {
                    MoveToLowerLeft();
                    MoveJudge(newPosition);
                }

                if (cannotMove)
                {
                    MoveToRight();
                    MoveJudge(newPosition);
                }
                if (cannotMove)
                {
                    MoveToLeft();
                    MoveJudge(newPosition);
                }

                if (cannotMove)
                {
                    Wait();
                    MoveJudge(newPosition);
                }
                break;
            case PositionRelation.UPPER_RIGHT:
                if (cannotMove)
                {
                    MoveToRight();
                    MoveJudge(newPosition);
                }
                if (cannotMove)
                {
                    MoveToUp();
                    MoveJudge(newPosition);
                }
                if (cannotMove)
                {
                    Wait();
                    MoveJudge(newPosition);
                }
                break;
            case PositionRelation.UPPER_LEFT:
                if (cannotMove)
                {
                    MoveToLeft();
                    MoveJudge(newPosition);
                }
                if (cannotMove)
                {
                    MoveToUp();
                    MoveJudge(newPosition);
                }
                if (cannotMove)
                {
                    Wait();
                    MoveJudge(newPosition);
                }
                break;
            case PositionRelation.LOWER_RIGHT:
                if (cannotMove)
                {
                    MoveToRight();
                    MoveJudge(newPosition);
                }
                if (cannotMove)
                {
                    MoveToDown();
                    MoveJudge(newPosition);
                }
                if (cannotMove)
                {
                    Wait();
                    MoveJudge(newPosition);
                }
                break;
            case PositionRelation.LOWER_LEFT:
                if (cannotMove)
                {
                    MoveToLeft();
                    MoveJudge(newPosition);
                }
                if (cannotMove)
                {
                    MoveToDown();
                    MoveJudge(newPosition);
                }
                if (cannotMove)
                {
                    Wait();
                    MoveJudge(newPosition);
                }
                break;
        }
    }
}