using UnityEngine;

public class Enemies : MonoBehaviour
{
    public AudioSource Enemy;
    public AudioClip death;

    public float health = 50f;

    public void TakeDamage(float amount){
        health -= amount;
        if(health <= 0f){
            Die();
        }
    }

    void Die(){
        Enemy.PlayOneShot(death);
        Destroy(gameObject);
        
    }
}
