using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Data;

public class HP : MonoBehaviour
{
    public Image fillBar;
    public TextMeshProUGUI valueTest;

    //cap nhat mau khi thay doi
    public void UpdateBar(int currentValue, int maxValue)
    {
        fillBar.fillAmount = (float)currentValue / (float)maxValue;
        valueTest.text = currentValue.ToString() + " / " + maxValue.ToString();
    }
}
