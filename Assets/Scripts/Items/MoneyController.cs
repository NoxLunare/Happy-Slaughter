using UnityEngine;
using UnityEngine.UI;

public class MoneyController : MonoBehaviour
{
    public Text moneyText;
    public Text monetShopText;

    public int addMoney;

    private void FixedUpdate()
    {
        moneyText.text = addMoney.ToString() + "$";
        monetShopText.text = addMoney.ToString() + "$";
    }


   
}
