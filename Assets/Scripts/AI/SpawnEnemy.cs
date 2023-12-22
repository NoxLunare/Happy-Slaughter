using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public List<GameObject> enemyList;

    public Transform postionPlayer;
    public Transform teleportPlayer;

    public bool isTrigger = false;
    public bool canSpawnEnemy = false;

    private void FixedUpdate()
    {
        SpawnEnemyTrigger();

        
       
    }
    public void SpawnEnemyTrigger()
    {
        if (isTrigger && Input.GetKeyDown(KeyCode.E))
        {
            SpawnEnemyController();
            TeleportArena();
        }
    }
    public void SpawnEnemyController()
    {
        for (int i = 0; i < Random.Range(4, 10); i++)
        {
            GameObject enemy = enemyList[Random.Range(0, enemyList.Count)];
            Vector3 spawnPoint = new Vector3(Random.Range(1, 17), 1, Random.Range(4, 23));
            Instantiate(enemy, spawnPoint, Quaternion.identity);

        }

    }

    public void TeleportArena()
    {
        postionPlayer.position = teleportPlayer.position;
        postionPlayer.rotation = teleportPlayer.rotation;
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
