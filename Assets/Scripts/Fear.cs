using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fear : MonoBehaviour
{
    private Image fearBar;
    float maxFear = 100f;
    public static float fearTime;
    public static float fearAmount;

    void Start()
    {
        fearBar = GetComponent<Image>();
        fearAmount = maxFear;
    }

    void Update()
    {
        fearBar.fillAmount = fearAmount / maxFear;
    }
}
