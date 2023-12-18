using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgraderController : MonoBehaviour
{
    public enum UpgradePlayer
    {
        damage
    }

    public UpgradePlayer currentUpgradePlayer;

    public Text scrapText;
    public Text upgradeDamagePlayerText;

    public int priceDamageScrap = 20;
    public int upgradeDamagePlayer;

    public bool canUpgrade = false;
    public void UpgradeDamage()
    {
        if (PlayerStats.Instance.scrap >= priceDamageScrap)
        {
            CurrentUpgradePlayer(UpgradePlayer.damage);
            canUpgrade = true;

            if (upgradeDamagePlayer >= 10)
            {
                canUpgrade = false;
                upgradeDamagePlayer = 10;
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
                BulletController.Instance.damage += 5;
                upgradeDamagePlayer++;
                scrapText.text = PlayerStats.Instance.scrap.ToString();
                upgradeDamagePlayerText.text = upgradeDamagePlayer.ToString();  
                break;
           
        }
    }
}
