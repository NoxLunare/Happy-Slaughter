using System;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Audio;
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

    public AudioMixer audioMixer;
   
    private int screenWidth = Screen.width;
    private int screenHeight = Screen.height;

    private const string mixerMusic = "Music";
    private const string mixerSfx = "SFX";
    private void Start()
    {
        try
        {
            sensivitySlider.value = PlayerPrefs.GetFloat("MouseSensivity", PlayerLookArround.Instance.sensivity);
            musicVolumeSlider.value = PlayerPrefs.GetFloat(mixerMusic, musicAudioSource.volume);
            sfxCVolumeSlider.value = PlayerPrefs.GetFloat(mixerSfx, sfxAudioSource.volume);
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

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat(mixerMusic,volume);
        PlayerPrefs.SetFloat(mixerMusic, musicVolumeSlider.value);
        PlayerPrefs.Save();

    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat(mixerSfx,volume);
        PlayerPrefs.SetFloat(mixerSfx, sfxCVolumeSlider.value);
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
