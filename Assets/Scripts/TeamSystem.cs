using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamSystem : MonoBehaviour
{
    
    public char ownTreasure;

    GameObject spawnPointA;
    GameObject spawnPointB;
    public GameObject player;

    

    // Start is called before the first frame update
    void Start()
    {
        spawnPointA = GameObject.Find("SpawnPointA");
        spawnPointB = GameObject.Find("SpawnPointB");

        int teamID = Random.Range(0,1);
        

        if(teamID == 0)
        {
            ownTreasure = 'A';
            player.transform.position = spawnPointA.transform.position;
            Physics.SyncTransforms();
        }
        else
        {
            ownTreasure = 'B';
            player.transform.position = spawnPointB.transform.position;
            Physics.SyncTransforms();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
