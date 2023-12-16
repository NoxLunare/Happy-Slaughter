using UnityEngine;
using UnityEngine.UI;

public class MoneyController : MonoBehaviour
{
    public static MoneyController Instance;
    public Text moneyText;
    public Text monetShopText;

    public int addMoney;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        moneyText.text = addMoney.ToString() + "$";
        monetShopText.text = addMoney.ToString() + "$";

        if(addMoney < 0)
        {
            addMoney = 0;
        }
    }


   
}
