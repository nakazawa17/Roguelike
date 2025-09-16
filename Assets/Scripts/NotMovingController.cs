using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotMovingObject : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerController player;

    [SerializeField] GameObject window;

    public void OpenWindow()
    {
        window.SetActive(true);

    }
    public void CloseWindow()
    {
        window.SetActive(false);
    }
    public virtual void SelectYes()
    {
    }
    public virtual void SelectNo()
    {
    }


}