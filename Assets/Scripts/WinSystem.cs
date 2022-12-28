using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class WinSystem : MonoBehaviour
{
    public bool teamATreasureDestroyed = false;
    public bool teamBTreasureDestroyed = false;
    public bool aWins = false;
    public bool bWins = false;

    GameObject inGameHUD;
    GameObject winHUD;
    GameObject defeatHUD;

    public TeamSystem team;


    // Start is called before the first frame update
    void Start()
    {
        inGameHUD.SetActive(true);

        inGameHUD = GameObject.Find("InGame HUD");
        winHUD = GameObject.Find("WinHUD");
        defeatHUD = GameObject.Find("LossHUD");
    }

    // Update is called once per frame
    void Update()
    {
        if (teamATreasureDestroyed)
        {
            bWins = true;

            inGameHUD.SetActive(false);

            if(team.ownTreasure == 'A')
            {
                defeatHUD.SetActive(true);
            }
            else
            {
                winHUD.SetActive(true);
            }
            
        } else if (teamBTreasureDestroyed)
        {
            aWins = true;

            inGameHUD.SetActive(false);

            if (team.ownTreasure == 'B')
            {
                defeatHUD.SetActive(true);
            }
            else
            {
                winHUD.SetActive(true);
            }
        }
    }
}
