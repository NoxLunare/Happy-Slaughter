using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public static SpawnEnemy Instance;
    public List<GameObject> enemyList;

    public Transform postionPlayer;
    public Transform teleportPlayer;
    public Transform teleportPlayerOut;

    public bool isTrigger = false;
    public bool canSpawnEnemy = false;

    public int countEnemy;

   public void  awake()
    {
       
    }
    private void FixedUpdate()
    {
        SpawnEnemyTrigger();

        /*if (countEnemy == 0)
        {
            TeleportArenaOut();
        }
        Debug.Log(countEnemy);
       */ 
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
            countEnemy++;

            if (Instance == null)
            {
                Instance = this;
            }
        }



       
    }


    public void TeleportArena()
    {
        postionPlayer.position = teleportPlayer.position;
        postionPlayer.rotation = teleportPlayer.rotation;
    }

    public void TeleportArenaOut()
    {
        postionPlayer.position = teleportPlayerOut.position;
        postionPlayer.rotation = teleportPlayerOut.rotation;
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
