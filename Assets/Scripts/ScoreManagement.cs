using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagement : MonoBehaviour
{
    public float playerDiamondsAmount = 0;
    public Text DiamondsAmountUI;
    // Update is called once per frame
    void Update()
    {
        DiamondsAmountUI.text = "Diam: " + playerDiamondsAmount.ToString();
    }
}
