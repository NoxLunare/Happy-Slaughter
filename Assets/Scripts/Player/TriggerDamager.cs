using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
   [SerializeField] PlayerStats playerStats;
 
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            playerStats.health--;
        }
    }

    
}
