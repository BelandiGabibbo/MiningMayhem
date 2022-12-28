using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInteract : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            this.GetComponent<Text>().color = new Color32(255, 255, 255, 70);
        }else if (Input.GetKeyUp(KeyCode.E))
        {
            this.GetComponent<Text>().color = new Color32(255, 255, 255, 255);
        }
                
    }
}
