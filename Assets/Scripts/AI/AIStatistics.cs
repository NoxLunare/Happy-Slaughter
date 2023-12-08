using UnityEngine;
using UnityEngine.UI;

public class AIStatistics : MonoBehaviour
{
    public GameObject moneyPrefab;

    public Slider sliderHp;

    public int health;
    public int maxHealth = 100;

    private void Start()
    {
        health = maxHealth;
        sliderHp.value = maxHealth;
    }

    private void Update()
    {
        HealthController();
        sliderHp.value = health;
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
        Destroy(newDrop,15);
    }
}
