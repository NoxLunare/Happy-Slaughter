using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public Toggle toggleFullscreen;
    public Dropdown dropdownResolution;

    private int screenWidth = Screen.width;
    private int screenHigh = Screen.height;

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetGraphicsLow()
    {
        QualitySettings.SetQualityLevel(0);
    }

    public void SetGraphicsMedium()
    {
        QualitySettings.SetQualityLevel(1);
    }

    public void SetGraphicsHigh()
    {
        QualitySettings.SetQualityLevel(2);
    }

    public void SetGraphicsUltra()
    {
        QualitySettings.SetQualityLevel(3);
    }

    public void ToogleFulscreen()
    {
        Screen.fullScreen = !Screen.fullScreen; 
    }

    public void DropDownResolution(int index)
    {
        switch (index)
        {
            case 0:
                screenWidth = 1920;
                screenHigh = 1080;
                break;
            case 1:
                screenWidth = 2560;
                screenHigh = 1440;
                break;
            case 2:
                screenWidth = 3840;
                screenHigh = 2160;
                break;
        }
    }
    public void BackMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
