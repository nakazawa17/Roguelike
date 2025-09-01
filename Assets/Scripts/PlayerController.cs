using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MovingController
{
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

    void Update()
    {
        if (isMoving)
        {
            MoveJudge(newPosition);
        }

    }

    protected override void MoveJudge(Vector3 newPosition)
    {
        base.MoveJudge(newPosition);
        newPosition = Vector3.zero;
        isMoving = false;
    }

}
