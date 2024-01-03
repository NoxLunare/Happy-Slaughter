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
        TryKillIfZeroHealth();
        sliderHp.value = health;
    }

    public void TryKillIfZeroHealth()
    {
        if (health <= 0)
        {
            DropMoney();
            PlayerStats.Instance.GetExp(2);
            PlayerStats.Instance.UpdateExpUI();
            PlayerStats.Instance.GetScrap(5);
            PlayerStats.Instance.UpdateScrapUI();
            health = 0;
            SpawnEnemy.Instance.countEnemy--;
            Debug.Log(SpawnEnemy.Instance.countEnemy);
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
