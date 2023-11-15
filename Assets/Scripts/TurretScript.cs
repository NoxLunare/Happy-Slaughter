using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretScript : MonoBehaviour
{
    public Transform player;
    public GameObject bulletPerfab;
    public Transform firePoint;
    public float fireRate = 2f;
    private float nextTimeToFire = 0f;
    int MaxDist = 15;
    int MinDist = 10;

    void Start() 
    {

    }

    void Update()
    {
      if (player != null) 
        {
            Vector3 directionToPlayer = player.position - transform.position;
            directionToPlayer.y = 0;
            Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

            if (Time.time >= nextTimeToFire) 
            {
                Shoot();
                nextTimeToFire = Time.time + 1f / fireRate;
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPerfab, firePoint.position, firePoint.rotation);
        BulletController bulletController = bullet.GetComponent<BulletController>();
    }
}
