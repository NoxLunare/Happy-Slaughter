using UnityEngine;

public class ShopOpen : MonoBehaviour
{
    public PlayerLookArround playerLookArround;
    public WeaponController weaponController;
    public GameObject shopUI;
    public GameObject playerUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Player")
        { 
            Cursor.visible = true;
            weaponController.enabled = false;
            playerLookArround.enabled = false;
            shopUI.SetActive(true);
            playerUI.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag =="Player")
        {
            Cursor.visible = false;
            weaponController.enabled = true;
            playerLookArround.enabled = true;
            shopUI.SetActive(false);
            playerUI.SetActive(true);
        }
    }
}
