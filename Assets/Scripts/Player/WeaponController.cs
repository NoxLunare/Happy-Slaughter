using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] Transform bulletPrefab;
    [SerializeField] Transform bulletSpawnerTransform;
    [SerializeField] float weaponCooldown;

    private void Update(){
        if(Input.GetMouseButtonDown(0)){
            Instantiate(bulletPrefab, bulletSpawnerTransform.position, bulletSpawnerTransform.rotation);
        }
    }
}
