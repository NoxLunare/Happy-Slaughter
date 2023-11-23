using UnityEngine;

public class AIStatistics : MonoBehaviour
{
    public GameObject moneyPrefab;

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
            DropMoney();    
            health = 0;
            Destroy(gameObject);    
        }
    }

    public void DropMoney()
    {
        Vector3 spawnDrop = gameObject.transform.position;
        GameObject newDrop = Instantiate(moneyPrefab, spawnDrop, Quaternion.identity);
    }
}
