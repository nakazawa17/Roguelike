using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEditor.Experimental.GraphView;


public abstract class MovingController : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private BoxCollider2D bc2d;


    protected bool cannotMove = true;

    public Vector3 newPosition = Vector3.zero;

    public virtual void MoveToRight()
    {
        newPosition = transform.position + new Vector3(1, 0, 0);
    }
    public virtual void MoveToLeft()
    {
        newPosition = transform.position + new Vector3(-1, 0, 0);
    }
    public virtual void MoveToUp()
    {
        newPosition = transform.position + new Vector3(0, 1, 0);
    }
    public virtual void MoveToDown()
    {
        newPosition = transform.position + new Vector3(0, -1, 0);
    }
    public virtual void MoveToUpperRight()
    {
        newPosition = transform.position + new Vector3(1, 1, 0);
        newPosition = newPosition.normalized;
    }
    public virtual void MoveToUpperLeft()
    {
        newPosition = transform.position + new Vector3(-1, 1, 0);
        newPosition = newPosition.normalized;
    }
    public virtual void MoveToLowerRight()
    {
        newPosition = transform.position + new Vector3(1, -1, 0);
        newPosition = newPosition.normalized;
    }
    public virtual void MoveToLowerLeft()
    {
        newPosition = transform.position + new Vector3(-1, -1, 0);
        newPosition = newPosition.normalized;
    }
    public virtual void Wait()
    {
        newPosition = transform.position;

    }


    protected virtual void MoveJudge(Vector3 newPosition)
    {
        Vector3 StartPosition = transform.position;

        int layerObj = LayerMask.GetMask(new string[] { "touchable" });

        this.rb2d = GetComponent<Rigidbody2D>();
        this.bc2d = GetComponent<BoxCollider2D>();

        bc2d.enabled = false;
        Vector3 dir = newPosition - StartPosition;
        RaycastHit2D hit2D = Physics2D.Linecast(StartPosition, newPosition, layerObj);
        Debug.DrawRay(StartPosition, dir, Color.magenta, 3f, false);

        bc2d.enabled = true;

        if (hit2D.collider == null)
        {
            cannotMove = false;
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
