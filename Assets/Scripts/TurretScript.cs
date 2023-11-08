using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretScript : MonoBehaviour
{
    public Transform player;
    int MaxDist = 15;
    int MinDist = 10;

    void Start() 
    {

    }

    void Update()
    {
      transform.LookAt(player);
    }
}
