using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookArround : MonoBehaviour
{
    public static PlayerLookArround Instance;   
    private float mouseHorizontal;
    private float mouseVertical;
    private float verticalRange = 90f;
    public float sensivity = 2f;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Update()
    {
        mouseHorizontal = Input.GetAxis("Mouse X") * sensivity;
        mouseVertical -= Input.GetAxis("Mouse Y") * sensivity;

        transform.Rotate(0, mouseHorizontal, 0);
        mouseVertical = Math.Clamp(mouseVertical,-verticalRange,verticalRange);
        Camera.main.transform.localRotation = Quaternion.Euler(mouseVertical,0,0);
    }
}
