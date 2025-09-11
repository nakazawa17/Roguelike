using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] TextMeshProUGUI stageNumber;
    [SerializeField] Animator animator;

    public void BlackOut(int stageCount)
    {
        panel.SetActive(true);
        animator.SetTrigger("MapUpdata");
        stageNumber.text = "B" + stageCount;
    }
}
