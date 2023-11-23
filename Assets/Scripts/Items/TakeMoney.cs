using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeMoney : MonoBehaviour
{
    [SerializeField] MoneyController moneyController;

    [SerializeField] float speed;

    private void Start()
    {
        moneyController = GameObject.Find("Game Manager").GetComponent<MoneyController>();
    }

    private void FixedUpdate()
    {
        transform.Rotate(0,speed * Time.deltaTime,0);
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
