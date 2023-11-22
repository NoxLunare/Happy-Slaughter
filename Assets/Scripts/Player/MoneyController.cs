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
            moneyText.text = addMoney.ToString();
            addMoney++;
            moneyName = moneyText.text = addMoney + " $ ";
            Destroy(money);
        }
    }
}
