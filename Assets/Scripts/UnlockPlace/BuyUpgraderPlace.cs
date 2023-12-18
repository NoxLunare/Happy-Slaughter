using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyUpgraderPlace : MonoBehaviour
{
    public GameObject placeUpgrader;
    public GameObject buttonUpgrader;
    public GameObject upgraderText;
    public GameObject closeUpgrader;

    private int priceUpgrader = 30;

    public bool canUpgrader = false;

    private void Start()
    {
        placeUpgrader.SetActive(false);
        buttonUpgrader.SetActive(true);
        upgraderText.SetActive(false);
        closeUpgrader.SetActive(true);
    }
    private void FixedUpdate()
    {
        BuyPlaceUpgrader();
    }

    public void BuyPlaceUpgrader()
    {
        if (Input.GetKey(KeyCode.E) && canUpgrader && MoneyController.Instance.addMoney >= priceUpgrader)
        {
            MoneyController.Instance.addMoney -= priceUpgrader;
            placeUpgrader.SetActive(true);
            buttonUpgrader.SetActive(false);
            upgraderText.SetActive(true);
            closeUpgrader.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canUpgrader = true;            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canUpgrader = false;
        }
    }

    private void OnGUI()
    {
        if (canUpgrader)
        {
            GUI.TextField(new Rect(1000, 1000, 250, 40), "Click E To Buy Upgrader Player For 30 $");
        }
    }

}
