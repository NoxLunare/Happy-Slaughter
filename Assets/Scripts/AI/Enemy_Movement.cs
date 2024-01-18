using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public Transform player;
    public int moveSpeed = 4;
    public int maxDist = 10;
    public int minDist = 1;

    private EnemyShooting enemyShooting; 

    void Start()
    {
        player = GameObject.Find("Player").transform;
        enemyShooting = GetComponent<EnemyShooting>(); 
    }

    void Update()
    {
        Vector3 directionToPlayer = player.position - transform.position;
        directionToPlayer.y = 0;
        Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

        if (Vector3.Distance(transform.position, player.position) >= minDist)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;

            if (Vector3.Distance(transform.position, player.position) <= maxDist)
            {
                enemyShooting.UpdateShooting();
            }
        }
    }
}
