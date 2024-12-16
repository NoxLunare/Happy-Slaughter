using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{
    [SerializeField] Transform bulletPrefab;
    [SerializeField] Transform bulletSpawnerTransform;

    [SerializeField] private Text ammoText;

    [SerializeField] private int ammo;
    [SerializeField] private int maxAmmo = 60;

    private bool canShoot = false;
    private bool isSoundShoot = false;

   
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
            PlayerStats.Instance.GetOverheating(2);
            AmmoController();

            if (!isSoundShoot && !PauseGame.Instance.isActiveMenuUI)
            {
                AudioManager.Instance.StartShootPlayerSound();
                isSoundShoot = true;
            }
            else if (isSoundShoot)
            {
                AudioManager.Instance.StopShootPlayerSound();
                isSoundShoot=false;
            }
        }
    }

    public void AmmoController()
    {
        canShoot = false;
        ammoText.text = ammo + "/" + maxAmmo;

        if (ammo > 0 && !PauseGame.Instance.isActiveMenuUI)
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
