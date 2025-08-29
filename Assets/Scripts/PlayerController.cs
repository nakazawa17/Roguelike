using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MovingController
{
    Vector3 newPosition = Vector3.zero;

    public Vector3 MoveRight()
    {
        newPosition.x = 1.0f;
        return newPosition;
    }

}
