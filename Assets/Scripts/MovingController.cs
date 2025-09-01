using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public abstract class MovingController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private BoxCollider2D bc2d;

    public Vector3 newPosition = Vector3.zero;
    void Start()
    {

    }

    public virtual void MoveToRight()
    {
        newPosition = transform.position + new Vector3(0.5f, 0, 0);
    }
    public virtual void MoveToLeft()
    {
        newPosition = transform.position + new Vector3(-0.5f, 0, 0);
    }
    public virtual void MoveToUp()
    {
        newPosition = transform.position + new Vector3(0, 0.5f, 0);
    }
    public virtual void MoveToDown()
    {
        newPosition = transform.position + new Vector3(0, -0.5f, 0);
    }


    protected virtual void MoveJudge(Vector3 newPosition)
    {
        Vector3 StartPosition = transform.position;

        this.rb2d = GetComponent<Rigidbody2D>();
        this.bc2d = GetComponent<BoxCollider2D>();
        bc2d.enabled = false;
        RaycastHit2D hit2D = Physics2D.Linecast(StartPosition, newPosition);
        bc2d.enabled = true;

        if (hit2D.transform == null)
        {
            StartCoroutine(MoveToNewPosition(newPosition));
        }

    }


    // Update is called once per frame
    void Update()
    {

    }

    public virtual IEnumerator MoveToNewPosition(Vector3 newPosition)
    {
        transform.DOMove(newPosition, 0.5f).SetEase(Ease.InOutQuart);
        yield return null;
    }
}
