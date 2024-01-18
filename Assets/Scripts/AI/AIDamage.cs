using UnityEngine;

public class AIDamage : MonoBehaviour
{
    public PlayerStats playerStats;
    public int damage = 2;

    private void Start()
    {
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerStats.currentHealth -= damage;
        }
    }
}
