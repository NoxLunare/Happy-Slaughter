using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{
    [SerializeField] GameObject light;
    [SerializeField] Transform bulletPrefab;
    [SerializeField] Transform bulletSpawnerTransform;

    [SerializeField] private Text ammoText;

    [SerializeField] private int ammo;
    [SerializeField] private int maxAmmo = 60;

    private bool canShoot = false;
    private bool isLight = false;
    private void Start()
    {
        ammo = maxAmmo;
    }
    private void Update()
    {
        ShootController();
        ReloadingController();
    }

    public void ShootController()
    {

        if (Input.GetMouseButtonDown(0))
        {
            isLight = !isLight;
            light.SetActive(isLight);
            PlayerStats.Instance.GetOverheating(5);
            AmmoController();
        }
    }

    public void AmmoController()
    {
        canShoot = false;
        ammoText.text = ammo + "/" + maxAmmo;

        if (ammo > 0)
        {
            canShoot = true;
            Instantiate(bulletPrefab, bulletSpawnerTransform.position, bulletSpawnerTransform.rotation);
            ammo--;
        }

        if (ammo >= maxAmmo)
        {
            ammo = maxAmmo;
        }
    }
    public void ReloadingController()
    {
        if (Input.GetKey(KeyCode.R))
        {
            ammo = maxAmmo;
        }
        if (ammo < 1)
        {
            ammo = maxAmmo;
        }
    }

}
