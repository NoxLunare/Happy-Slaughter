using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public List<GameObject> enemyList;

    public bool isTrigger = false;

    
    void Start()
    {
        SpawnEnemyController();
    }

    private void FixedUpdate()
    {
        SpawnEnemyTrigger();
    }

    public void SpawnEnemyTrigger()
    {
        if (isTrigger && Input.GetKey(KeyCode.E))
        {
            SpawnEnemyController();
        }
    }
    public void SpawnEnemyController()
    {
        for (int i = 0; i < Random.Range(5,10); i++)
        {
            GameObject enemy = enemyList[Random.Range(0, enemyList.Count)];
            Vector3 spawnPoint = new Vector3(Random.Range(-40, 10), 1, Random.Range(-26, 26));
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
            GUI.TextField( new Rect(1000,1000,250,40), "Click E To Spawn Enemy");
        }
    }

}
