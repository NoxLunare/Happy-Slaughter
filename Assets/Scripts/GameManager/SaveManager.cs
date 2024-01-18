using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

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
    private void Start()
    {
        Load();
    }

    public void Load()
    {
        MoneyController.Instance.addMoney = PlayerPrefs.GetInt("saveMoney", MoneyController.Instance.addMoney);
        PlayerStats.Instance.scrap = PlayerPrefs.GetInt("saveScrap", PlayerStats.Instance.scrap);
        PlayerStats.Instance.currentExp = PlayerPrefs.GetInt("saveExp", PlayerStats.Instance.currentExp);
        PlayerStats.Instance.maxExp = PlayerPrefs.GetInt("saveMaxExp", PlayerStats.Instance.maxExp);
        PlayerStats.Instance.levelPlayer = PlayerPrefs.GetInt("saveLevel", PlayerStats.Instance.levelPlayer);
   
        BuyUpgraderPlace.Instance.buyUpgrader = PlayerPrefs.GetInt("saveBuyUpgrader", BuyUpgraderPlace.Instance.buyUpgrader);

        if (BuyUpgraderPlace.Instance.buyUpgrader == 1)
        {
            BuyUpgraderPlace.Instance.placeUpgrader.SetActive(true);
            BuyUpgraderPlace.Instance.closeUpgrader.SetActive(false);
        }

        PlayerStats.Instance.currentHealth = PlayerPrefs.GetFloat("saveHealth", PlayerStats.Instance.currentHealth);
        PlayerStats.Instance.overheating = PlayerPrefs.GetFloat("saveOverheating", PlayerStats.Instance.overheating);


    }
    public void SavePlayerStats()
    {
        PlayerPrefs.SetInt("saveMoney", MoneyController.Instance.addMoney);
        PlayerPrefs.SetInt("saveScrap", PlayerStats.Instance.scrap);
        PlayerPrefs.SetInt("saveExp", PlayerStats.Instance.currentExp);
        PlayerPrefs.SetInt("saveMaxExp", PlayerStats.Instance.maxExp);
        PlayerPrefs.SetInt("saveLevel", PlayerStats.Instance.levelPlayer);
     
        PlayerPrefs.SetInt("saveBuyUpgrader", BuyUpgraderPlace.Instance.buyUpgrader);
  

        PlayerPrefs.SetFloat("saveHealth", PlayerStats.Instance.currentHealth);
        PlayerPrefs.SetFloat("saveOverheating", PlayerStats.Instance.overheating);
        PlayerPrefs.Save();
    }
    public void SavePlayerUpgrade()
    {
        PlayerPrefs.SetInt("saveUpgradeDamagePlayer", UpgraderController.Instance.upgradeDamagePlayer);
        PlayerPrefs.SetInt("saveCurrentUpgradeDamageUI", UpgraderController.Instance.currentUpgradeDamageUI);

        PlayerPrefs.Save();
    }

   
}
