using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public List<GameObject> enemyList;
    void Start()
    {
        SpawnEnemyController();
    }

    public void SpawnEnemyController()
    {
        for (int i = 0; i < Random.Range(15,30); i++)
        {
            GameObject enemy = enemyList[Random.Range(0,enemyList.Count)];
            Vector3 spawnPoint = new Vector3(Random.Range(-40,10),1, Random.Range(-26, 26));
            Instantiate(enemy, spawnPoint,Quaternion.identity);  
        }
    }
  
}
