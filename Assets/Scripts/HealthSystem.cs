using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public float health = 100f;

    public Death death;
    HealthBarScript healthBar;
    Text healthAmountUI;
    // Start is called before the first frame update
    void Start()
    {
        health = 100f;

        healthBar = GameObject.Find("HealthBar").GetComponent<HealthBarScript>();
        healthAmountUI = GameObject.Find("Health Amount").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0f)
        {
            Die();
            health = 100f;
        }

        healthAmountUI.text = health.ToString();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        death.isDead = true;
    }
}
