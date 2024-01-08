using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnRoomController : MonoBehaviour
{
    public int openingDirection;
    public RoomTemplates templates;

    public  Vector3 spawnRoom;
  
    private void Start()
    {
        spawnRoom = gameObject.transform.position;
        SpawnRoom();
    }

   public void SpawnRoom()
    {
      
        if (openingDirection == 1)
        {
            int random = Random.Range(0, templates.bottomRoomsList.Count);
            Instantiate(templates.bottomRoomsList[random], spawnRoom,Quaternion.identity);
        }

        if (openingDirection == 2)
        {
            int random = Random.Range(0, templates.topRoomsList.Count);
            Instantiate(templates.topRoomsList[random], spawnRoom, Quaternion.identity);
        }

        if(openingDirection == 3)
        {
            int random = Random.Range(0, templates.leftRoomsList.Count);
            Instantiate(templates.leftRoomsList[random], spawnRoom, Quaternion.identity);
        }

        if (openingDirection == 4)
        {
            int random = Random.Range(0, templates.rightRoomsList.Count);
            Instantiate(templates.rightRoomsList[random], spawnRoom, Quaternion.identity);
        }
    }

}
