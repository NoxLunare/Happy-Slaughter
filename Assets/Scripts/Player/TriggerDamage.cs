using UnityEngine;

public class TriggerDamager : MonoBehaviour
{
   [SerializeField] PlayerStats playerStats;


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            playerStats.health -= 4 * Time.deltaTime;
        }
    }
}
