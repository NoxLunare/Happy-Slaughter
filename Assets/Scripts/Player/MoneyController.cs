using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoneyController : MonoBehaviour
{
    public GameObject money;

    public Text moneyText;

    public int addMoney;

    private string moneyName;
   
   private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            addMoney++;
            moneyText.text = addMoney.ToString();
            moneyName = moneyText.text = addMoney + " $ ";
            Destroy(money);
          
        }
    }
}
