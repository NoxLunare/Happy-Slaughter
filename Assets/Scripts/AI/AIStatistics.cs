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
       
    }

    private void Update()
    {
        HealthController();
        sliderHp.value = health;
    }

    public void HealthController()
    {

        if (health > 0)
        {
            sliderHp.value = maxHealth;
        }

        if (health <= 0)
        {
            DropMoney();
            PlayerStats.Instance.GetExp(2);
            PlayerStats.Instance.UpdateExpUI();
            PlayerStats.Instance.GetScrap(5);
            PlayerStats.Instance.UpdateScrapUI();
            SaveManager.Instance.Save();
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
