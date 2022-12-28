using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.HighDefinition;

public class Death : MonoBehaviour
{
    public bool isDead = false;
    public bool isAlive = true;

    public float timePassed = 3;
    public int countdownConverted;

    public GameObject player;
    public GameObject playerWoCamera;
    
    GameObject blackWhite;
    GameObject healthBar;

    public HealthSystem health;

    Text countdownUI;

    public InputManager movement;
    public SniperShoot sniperAim;
    public TeamSystem team;

    GameObject spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        blackWhite = GameObject.Find("Black&White");
        healthBar = GameObject.Find("HealthBar");
        countdownUI = GameObject.Find("Countdown").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(team.ownTreasure == 'A')
        {
            spawnPoint = GameObject.Find("SpawnPointA");
        }
        else
        {
            spawnPoint = GameObject.Find("SpawnPointB");
        }

        if (isDead)
        {
            blackWhite.SetActive(true);
            healthBar.SetActive(false);

            isAlive = false;
            sniperAim.StopADS();
            playerWoCamera.SetActive(false);   

            countdownUI.text = UnityEngine.Mathf.Floor(timePassed+1).ToString();

            timePassed -= Time.deltaTime;
            countdownUI.gameObject.SetActive(true);

            if (timePassed < 0)
            {
                
                player.transform.position = spawnPoint.transform.position;
                Physics.SyncTransforms();
                playerWoCamera.SetActive(true);
                

                isDead = false;
                isAlive = true;
                countdownUI.gameObject.SetActive(false);
                blackWhite.SetActive(false);
                healthBar.SetActive(true);
                health.health = 100f;
                timePassed = 3;
            }
        }
    }
}
