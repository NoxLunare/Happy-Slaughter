using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public List<GameObject> enemyList;

    public bool isTrigger = false;
    private void FixedUpdate()
    {
        SpawnEnemyTrigger();
    }
    public void SpawnEnemyTrigger()
    {
        if (isTrigger && Input.GetKeyDown(KeyCode.E))
        {
            SpawnEnemyController();
        }
    }
    public void SpawnEnemyController()
    {
        for (int i = 0; i < Random.Range(4,10); i++)
        {
            GameObject enemy = enemyList[Random.Range(0, enemyList.Count)];
            Vector3 spawnPoint = new Vector3(Random.Range(1, 17), 1, Random.Range(4, 23));
            Instantiate(enemy, spawnPoint, Quaternion.identity);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Player")
        {
            isTrigger = true;
          
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isTrigger = false;
        }
    }

    private void OnGUI()
    {
        if (isTrigger)
        {
            GUI.TextField( new Rect(1000,1000,250,40), "Hold E To Spawn Enemy");
        }
    }

}
