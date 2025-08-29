using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class MovingController : MonoBehaviour
{
    void Start()
    {

    }
    /*
    protected void SmoothMove(Vector3 end)
    {

        // 現在地と目的地の差(残り距離)
        float goleDistance = (transform.position - end).sqrMagnitude;
        // 残り距離がEpsilon(限りなく0に近い少数)よりも小さくなるまで
        while (goleDistance > float.Epsilon)
        {
            Vector3 newPosition = Vector3.MoveTowards(rb2D.position, end,)
        }
    }
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }
    */

    public virtual void MoveTo(Vector3 newPosition)
    {
        transform.DOMove(newPosition, 1f).SetEase(Ease.InOutQuart);
    }
}
