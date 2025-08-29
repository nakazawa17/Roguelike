using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingController : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public float moveTime = 0.1f;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    protected void SmoothMove(Vector3 end)
    {

        // 現在地と目的地の差(残り距離)
        float goleDistance = (transform.position - end).sqrMagnitude;
        // 残り距離がEpsilon(限りなく0に近い少数)よりも小さくなるまで
        while (goleDistance > float.Epsilon)
        {
            Vector3 newPosition = Vector3.MoveTowards()
        }
    }
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        float sqr
    }
}
