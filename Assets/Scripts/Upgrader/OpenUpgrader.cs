using UnityEngine;

public class OpenUpgrader : MonoBehaviour
{
    public WeaponController weaponController;
    public PlayerLookArround playerLookArround;
    public GameObject upgraderUI;
    public GameObject playerUI;
    public bool isTrigger = false;

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isTrigger = true;
            Cursor.visible = true;
            weaponController.enabled = false;
            playerLookArround.enabled = false;
            upgraderUI.SetActive(true);
            playerUI.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag =="Player")
        {
            isTrigger =false;
            Cursor.visible = false;
            weaponController.enabled = true;
            playerLookArround.enabled = true;
            upgraderUI.SetActive(false);
            playerUI.SetActive(true);
        }
    }
}
