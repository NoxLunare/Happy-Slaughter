using UnityEngine;

public class QuitArenaController : MonoBehaviour
{
    public static QuitArenaController Instance;

    [SerializeField] private Transform playerPostion;
    [SerializeField] private Transform quitArena;

    private bool isTrigger = false;
    public bool isClose = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;   
        }
    }
    private void FixedUpdate()
    {
        if (isTrigger && SpawnEnemy.Instance.countEnemy == 0)
        {
            playerPostion.transform.position = quitArena.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isTrigger = true;      
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag =="Player")
        {
            isTrigger = false;
        }
    }
}
