using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DamageZone : MonoBehaviour
{
    public HealthSystem health;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            health.health -= 10;
        }
    }
}
