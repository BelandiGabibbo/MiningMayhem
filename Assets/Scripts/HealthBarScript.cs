using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Slider slider;

    public Image fill;
    HealthSystem health;

    public void Start()
    {
        health = GameObject.Find("Player").GetComponent<HealthSystem>();

        slider.maxValue = health.health;
    }

    public void Update()
    {
        
        slider.value = health.health;

        if(slider.value > 50)
        {
            fill.color = Color.green;
        }else if(slider.value > 25 && slider.value < 50)
        {
            fill.color = Color.yellow;
        }else if(slider.value < 25){
            fill.color = Color.red;
        }
    }
}
