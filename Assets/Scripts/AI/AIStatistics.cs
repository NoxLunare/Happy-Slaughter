using UnityEngine;

public class AIStatistics : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        HealthController();
    }

    public void HealthController()
    {
        if (health <= 0)
        {
            health = 0;
            Destroy(gameObject);    
        }
    }
}
