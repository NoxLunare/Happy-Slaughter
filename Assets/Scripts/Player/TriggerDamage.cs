using UnityEngine;

public class TriggerDamager : MonoBehaviour
{
   [SerializeField] PlayerStats playerStats;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Player")
        {
            playerStats.health -= Random.Range(10,30);
        
        }
    }
}
