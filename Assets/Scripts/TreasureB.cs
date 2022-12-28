using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Audio;

public class TreasureB : MonoBehaviour
{
    public float totalDiamonds = 100;

    public float timePassed = 0f;
    public float delayAmount;
    public float opacity = 0.25f;

    public bool isInTrigger;
    public bool isInteracting;
    public bool isSoundPlayed = false;

    public AudioSource cubeSource;
    public AudioSource captureZoneSource;
    public AudioClip looting;
    public AudioClip looted;

    Text diamondsAmountUI;
    GameObject eLoot;
    ScoreManagement PlayerDiamonds;
    Death death;
    WinSystem winSystem;
    TeamSystem team;

    // Start is called before the first frame update
    void Start()
    {
        diamondsAmountUI = GameObject.Find("Diamonds").GetComponent<Text>();
        eLoot = GameObject.Find("[E] Loot");
        PlayerDiamonds = GameObject.Find("Diamonds").GetComponent<ScoreManagement>();
        death = GameObject.Find("Player").GetComponent<Death>();
        winSystem = GameObject.Find("Player").GetComponent<WinSystem>();
        team = GameObject.Find("Player").GetComponent<TeamSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(totalDiamonds <= 0)
        {
            eLoot.SetActive(false);
            Destroy(this.gameObject);
            cubeSource.Play();

            winSystem.teamBTreasureDestroyed = true;
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            isInteracting = true;
        }
        else if(Input.GetKeyUp(KeyCode.E))
        {
            isInteracting = false;
            isSoundPlayed = false;
        }

        if (((isInTrigger && isInteracting) && death.isAlive))
        {

            if (!isSoundPlayed)
            {
                captureZoneSource.Play(0);
                isSoundPlayed = true;
            }
            
            timePassed += Time.deltaTime;
            if(timePassed > 1f)
            {
                totalDiamonds -= 2f;
                PlayerDiamonds.playerDiamondsAmount += 2f;
                timePassed = 0;
            }
        }
        else
        {
            captureZoneSource.Pause();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Player"))
        {
            if(team.ownTreasure == 'A')
            {
                isInTrigger = true;
                eLoot.SetActive(true);
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((other.tag == "Player"))
        {
            if (team.ownTreasure == 'A')
            {
                isInTrigger = false;
                eLoot.SetActive(false);
                captureZoneSource.Pause();
                isSoundPlayed = false;
            }
        }
    }
}

    
