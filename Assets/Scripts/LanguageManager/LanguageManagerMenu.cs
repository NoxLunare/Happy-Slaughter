using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class LanguageManagerMenu : MonoBehaviour
{
 
    public TMP_Dropdown languageDropdown;
    public Text[] textsToTranslate;


    public string[] translationKeys;


    private Dictionary<string, Dictionary<string, string>> translations = new Dictionary<string, Dictionary<string, string>>()
    {
        {
            "English", new Dictionary<string, string>()
            {
                
            {"GameNameText", "Happy Slaughter"},
            {"PlayText", "Play"},
            {"SettingsText", "Settings"},
            {"QuitGameText", "Exit"},

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
         
           
            }
        },
        {
            "Polish", new Dictionary<string, string>()
            {
 
            {"GameNameText", "Szczęśliwa Rzeź"},
            {"PlayText", "Graj"},
            {"SettingsText","Ustawienia"},
            {"QuitGameText", "Wyjście"},

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
             
            }


        },
        {
            "Chinese", new Dictionary<string, string>()
            {

            {"GameNameText", "屠宰快乐"},
            {"PlayText", "玩"},
            {"SettingsText", "设置"},
            {"QuitGameText", "退出游戏"},

            {"GrahpicsText", "形象的"},
            {"LowText", "低的"},
            {"MediumText", "平均的"},
            {"HighText", "高的"},
            {"UltraText", "极端主义者"},

            {"ResolutionText", "解决"},
            {"LanguageText", "舌头"},
            {"LabelFullscreenText", "全屏"},
            {"GameText", "游戏"},

            {"SensivityText", "灵敏度"},
            {"MusicText", "音乐"},
            {"SFXText", "特效"},

            {"BackText", "回来"},


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