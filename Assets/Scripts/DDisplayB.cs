using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDisplayB : MonoBehaviour
{
    GameObject textMesh;
    GameObject mainCamera;

    public TreasureB totalDiamondsB;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GameObject.Find("Diamonds Amount Display");
    }

    // Update is called once per frame
    void Update()
    {
        mainCamera = GameObject.FindGameObjectWithTag("Camera");

        textMesh.transform.rotation = mainCamera.transform.rotation;


        textMesh.GetComponent<TextMesh>().text = totalDiamondsB.totalDiamonds.ToString();
    }
}
