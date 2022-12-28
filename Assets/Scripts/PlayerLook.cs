using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;

    public float xSensitivity = 30f;
    public float ySensitivity = 30f;

    public float xScopeSensitivity = 15f;
    public float yScopeSensitivity = 15f;

    public SniperShoot Sniper;

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        if (Sniper.isAiming == false)
        {
            xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        }
        else
        {
            xRotation -= (mouseY * Time.deltaTime) * yScopeSensitivity;
        }

        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        cam.transform.localRotation = Quaternion.Euler(xRotation,0,0);

        if(Sniper.isAiming == false)
        {
            transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
        }
        else
        {
            transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xScopeSensitivity);
        }
        
    }

    void Update(){
        Cursor.lockState = CursorLockMode.Locked;
    }

}