using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private TextMeshProUGUI stageNumber;
    public float feedSpeed = 0.03f;
    float red, green, blue;

    void Awake()
    {
        stageNumber = GetComponent<TextMeshProUGUI>();
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
