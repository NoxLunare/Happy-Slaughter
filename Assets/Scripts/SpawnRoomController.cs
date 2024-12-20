using UnityEngine;

public class SpawnRoomController : MonoBehaviour
{
    public int openingDirection;

    public RoomTemplates templates;

    public  Transform spawnRoom;
 
    private void Start()
    {
        templates = GameObject.Find("Game Manager").GetComponent<RoomTemplates>();
        Invoke("SpawnRoom",0.1f);
    }

   public void SpawnRoom()
    {

        if (openingDirection == 1)
        {
            int random = Random.Range(0, templates.bottomRoomsList.Count);
            Instantiate(templates.bottomRoomsList[random], spawnRoom.position, Quaternion.identity);
        }

        if (openingDirection == 2)
        {
            int random = Random.Range(0, templates.topRoomsList.Count);
            Instantiate(templates.topRoomsList[random], spawnRoom.position, Quaternion.identity);
        }

        if(openingDirection == 3)
        {
            int random = Random.Range(0, templates.leftRoomsList.Count);
            Instantiate(templates.leftRoomsList[random], spawnRoom.position, Quaternion.identity);
        }

        if (openingDirection == 4)
        {
            int random = Random.Range(0, templates.rightRoomsList.Count);
            Instantiate(templates.rightRoomsList[random], spawnRoom.position, Quaternion.identity);
        }
    }

}
