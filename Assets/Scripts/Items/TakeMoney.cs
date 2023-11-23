using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeMoney : MonoBehaviour
{
    [SerializeField] MoneyController moneyController;

    private void Start()
    {
        moneyController = GameObject.Find("Game Manager").GetComponent<MoneyController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Player")
        {
            moneyController.addMoney++;
            Destroy(gameObject);
        }
    }
}
