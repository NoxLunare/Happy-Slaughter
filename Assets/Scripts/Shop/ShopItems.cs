using UnityEngine;
using UnityEngine.UI;

public class ShopItems : MonoBehaviour
{
    
    [SerializeField] private int priceSmallHealthItem = 5;
    [SerializeField] private int pricesBigHealthItem = 25;
    [SerializeField] private int pricesRepairOverheatingItem = 35;

    [SerializeField] private float takeSmallBaterryHealth = 30;
    [SerializeField] private float takersBigBaterryHealth = 80;

    [SerializeField] private int takerOverheating = 20;

    [SerializeField] Text priceSmallHealthItemText;
    [SerializeField] Text pricesBigHealthItemText;
    [SerializeField] Text pricesOverheatingText;
    public enum itemShop
    {
        smallBatteryHealth,
        bigBatteryHealth,
        RepairOverheating
    }

    public itemShop currentItem;

    public void SmallBatteryHealth()
    {
        if (MoneyController.Instance.addMoney >= priceSmallHealthItem)
        {
            if (PlayerStats.Instance.currentHealth < 100)
            {
                CurrentItemShop(itemShop.smallBatteryHealth);
            }
        }
    }
    public void BigBatteryHealth()
    {
        if (MoneyController.Instance.addMoney >= pricesBigHealthItem)
        {
            if (PlayerStats.Instance.currentHealth < 100)
            {
                CurrentItemShop(itemShop.bigBatteryHealth);
            }
        }
    }
    public void RepairOverheating()
    {
        if (MoneyController.Instance.addMoney >= pricesRepairOverheatingItem)
        {
            if (PlayerStats.Instance.overheating <= 100)
            {
                CurrentItemShop(itemShop.RepairOverheating);
            }
        }
    }
    public void CurrentItemShop(itemShop itemShop)
    {
        currentItem = itemShop;
        ItemController(itemShop);
    }

    public void ItemController(itemShop currentItem)
    {
        switch (currentItem)
        {
            case itemShop.smallBatteryHealth:
                priceSmallHealthItemText.text = priceSmallHealthItem.ToString() + " $";
                PlayerStats.Instance.currentHealth += takeSmallBaterryHealth;
                MoneyController.Instance.addMoney -= priceSmallHealthItem;
                SaveManager.Instance.SavePlayerStats();
                break;
            case itemShop.bigBatteryHealth:
                pricesBigHealthItemText.text = pricesBigHealthItem.ToString() + " $";
                PlayerStats.Instance.currentHealth += takersBigBaterryHealth;
                MoneyController.Instance.addMoney -= pricesBigHealthItem;
                SaveManager.Instance.SavePlayerStats();
                break;
            case itemShop.RepairOverheating:
                pricesOverheatingText.text = pricesRepairOverheatingItem.ToString() + " $";
                PlayerStats.Instance.overheating -= takerOverheating; 
                MoneyController.Instance.addMoney -= pricesBigHealthItem;
                SaveManager.Instance.SavePlayerStats();
                break;
        }
    }
}
