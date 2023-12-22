using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgraderController : MonoBehaviour
{
    public static UpgraderController Instance;
    public enum UpgradePlayer
    {
        damage
    }

    public UpgradePlayer currentUpgradePlayer;

    public Text scrapText;
    public Text upgradeDamagePlayerText;

    public int priceDamageScrap = 20;
    public int currentUpgradeUI;
    public int upgradeDamagePlayer = 5;

    public bool canUpgrade = false;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
       
    }
    public void UpgradeDamage()
    {
        if (PlayerStats.Instance.scrap >= priceDamageScrap)
        {
            CurrentUpgradePlayer(UpgradePlayer.damage);
            canUpgrade = true;

            if (currentUpgradeUI > 9)
            {
                canUpgrade = false;
                currentUpgradeUI = 10;
            }
        }
    }

    public void CurrentUpgradePlayer(UpgradePlayer upgradePlayer)
    {
        currentUpgradePlayer = upgradePlayer;
        UpgradePlayerController(upgradePlayer);
    }

    public void UpgradePlayerController(UpgradePlayer currentUpgrade)
    {
        switch (currentUpgrade)
        {   
            case UpgradePlayer.damage:
                PlayerStats.Instance.scrap -= priceDamageScrap;
                BulletController.Instance.damage += upgradeDamagePlayer;
                currentUpgradeUI++;
                scrapText.text = PlayerStats.Instance.scrap.ToString();
                upgradeDamagePlayerText.text = currentUpgradeUI.ToString();
                SaveManager.Instance.Save();
                break;
           
        }
    }
}
