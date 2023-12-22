using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitArenaController : MonoBehaviour
{
    [SerializeField] private Transform playerPostion;
    [SerializeField] private Transform quitArena;

    private bool isTrigger = false;
   
    private void FixedUpdate()
    {
        if (isTrigger)
        {
            playerPostion.transform.position = quitArena.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isTrigger = true;      
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag =="Player")
        {
            isTrigger = false;
        }
    }
}
