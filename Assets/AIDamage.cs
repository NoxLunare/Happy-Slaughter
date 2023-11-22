using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDamage : MonoBehaviour
{
    public PlayerStats playerStats;
    public int damage = 2;
   public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerStats.health -= damage;
        }
    }
}
