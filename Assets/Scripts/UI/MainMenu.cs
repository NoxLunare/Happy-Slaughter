using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public Toggle toggleFullscreen;

    public TMP_Dropdown dropdownResolution;

    public Slider sensivitySlider;

    public Slider musicVolumeSlider;
    public Slider sfxCVolumeSlider;
   
    public AudioSource musicAudioSource;
    public AudioSource sfxAudioSource;

    private int screenWidth = Screen.width;
    private int screenHeight = Screen.height;

    private void Start()
    {
        try
        {
            sensivitySlider.value = PlayerPrefs.GetFloat("MouseSensivity", PlayerLookArround.Instance.sensivity);
            musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", musicAudioSource.volume);
            sfxCVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume", sfxAudioSource.volume);
        }
        catch (NullReferenceException)
        {

        }
       
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Cube_Forest");
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

    public void SetSensivity()
    {
        float sensitivity = sensivitySlider.value;
        PlayerLookArround.Instance.sensivity = sensitivity;
        PlayerPrefs.SetFloat("MouseSensivity",PlayerLookArround.Instance.sensivity);
        PlayerPrefs.Save();
    }

    public void SetMusicVolume()
    {
        float musicVolume = musicVolumeSlider.value;
        musicAudioSource.volume = musicVolume;
        PlayerPrefs.SetFloat("MusicVolume",musicVolume);
        PlayerPrefs.Save();
    }

    public void SetSFXVolume()
    {
        float sfxVolume = sfxCVolumeSlider.value;
        sfxAudioSource.volume = sfxVolume;
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
        PlayerPrefs.Save();
    }
    public void ToogleFulscreen()
    {
        if (toggleFullscreen.isOn)
        {
            Screen.fullScreen = true;
        }
        else if (toggleFullscreen.isOn == false)
        {
            Screen.fullScreen= false;   
        }
    }

    public void DropDownResolution()
    {
        switch (dropdownResolution.value)
        {
            case 0:
                screenWidth = 1920;
                screenHeight = 1080;
                break;
            case 1:
                screenWidth = 2560;
                screenHeight = 1440;
                break;
            case 2:
                screenWidth = 3840;
                screenHeight = 2160;
                break;

            default:
                screenWidth = 1920;
                screenHeight = 1080;
                break;
        }
    }
    public void BackMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
