using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LanguageManagerGame : MonoBehaviour
{
    public TMP_Dropdown languageDropdown;
    public Text[] textsToTranslate;


    public string[] translationKeys;


    private Dictionary<string, Dictionary<string, string>> translations = new Dictionary<string, Dictionary<string, string>>()
    {
        {
            "English", new Dictionary<string, string>()
            {
            
              {"PauseGameText", "Pause Game"},
              {"ResumeText", "Resume"},
              {"SettingsText", "Settings"},
              {"MainMenuText", "Main menu"},

            {"GrahpicsText", "Graphics"},
            {"LowText", "Low"},
            {"MediumText", "Medium"},
            {"HighText", "High"},
            {"UltraText", "Ultra"},

            {"ResolutionText", "Resolution"},
            {"LanguageText", "Language"},
            {"LabelFullscreenText", "Fullscreen"},
            {"GameText", "Game"},

            {"SensivityText", "Sensivity"},
            {"MusicText", "Music"},
            {"SFXText", "SFX"},

            {"BackText", "Back"},

              {"ShopText", "Shop"},
              {"ItemsText", "Items"},
              {"PriceText", "Price"},
              {"AmountText", "Amount"},
              {"BuyText", "Buy"},


              {"UpgraderText", "Upgrader"},            
              {"PlayerText", "Player"},    
              {"ScrapText", "Scrap"},         
              {"UpgradeText", "Upgrade"},

               
            
              {"ExitArenaText", "Exit Arena"},

            }
        },
        {
            "Polish", new Dictionary<string, string>()
            {
               
              {"PauseGameText", "Pauza Gry"},
              {"ResumeText", "Wznów"},
              {"SettingsText", "Ustawienia"},
              {"MainMenuText", "Wróć do menu"},


              {"GrahpicsText", "Graficzne"},
              {"LowText", "Niskie"},
              {"MediumText", "Średnie"},
              {"HighText", "Wysokie"},
              {"UltraText", "Ultra"},

              {"ResolutionText", "Rozdzielczość"},
              {"LanguageText", "Język"},
              {"LabelFullscreenText", "Pełny Ekran"},
              {"GameText", "Gra"},

              {"SensivityText", "Czułość"},
              {"MusicText", "Muzyka"},
              {"SFXText", "Efekty Specjalne"},

              {"BackText", "Wróć"},
   
              {"ShopText", "Sklep"},
              {"ItemsText", "Przedmioty"},
              {"PriceText", "Cena"},
              {"AmountText", "Ilość"},
              {"BuyText", "Kup"},
     
              {"UpgraderText", "Ulepszacz"},  
              {"PlayerText", "Gracz"},            
              {"ScrapText", "Złom"},                
              {"UpgradeText", "Ulepsz"},

                
             
              {"ExitArenaText", "Wyjście z areny"},
          
            }
        },
         {
            "Chinese", new Dictionary<string, string>()
            {

              {"PauseGameText", "游戏暂停"},
              {"ResumeText", "恢复"},
              {"SettingsText", "设置"},
              {"MainMenuText", "返回菜单"},


              {"GrahpicsText", "形象的"},
              {"LowText", "低的"},
              {"MediumText", "平均的"},
              {"HighText", "高的"},
              {"UltraText", "极端主义者"},

              {"ResolutionText", "解决"},
              {"LanguageText", "舌头"},
              {"LabelFullscreenText", "“全屏”"},
              {"GameText", "游戏"},

              {"SensivityText", "灵敏度"},
              {"MusicText", "音乐"},
              {"SFXText", "特效"},

              {"BackText", "回来"},

              {"ShopText", "店铺"},
              {"ItemsText", "项目"},
              {"PriceText", "价格"},
              {"AmountText", "数量"},
              {"BuyText", "买"},

              {"UpgraderText", "改进剂"},
              {"PlayerText", "玩家"},
              {"ScrapText", "废料"},
              {"UpgradeText", "提升"},



              {"ExitArenaText", "离开赛场"},


            }
        },

    };



    void Start()
    {
        languageDropdown.ClearOptions();
        languageDropdown.AddOptions(new List<string> { "English", "Polish", "Chinese" });
        languageDropdown.onValueChanged.AddListener(ChangeLanguage);

        ChangeLanguage(0);

    }

    public void ChangeLanguage(int index)
    {
        string selectedLanguage = languageDropdown.options[index].text;

        Text[] allUITexts = Resources.FindObjectsOfTypeAll<Text>();
        foreach (Text uiText in allUITexts)
        {
            if (translations[selectedLanguage].TryGetValue(uiText.name, out string translatedValue))
            {
                uiText.text = translatedValue;
            }
            else
            {
                Debug.LogWarning($"Missing translation for '{uiText.name}' in language '{selectedLanguage}'");
            }
        }


    }
}
