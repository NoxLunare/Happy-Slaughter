using System;
using System.Reflection;
using TMPro;
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

    private readonly Vector2Int[] resolutions =
   {
     new Vector2Int(1280, 720),
     new Vector2Int(1920, 1080),
     new Vector2Int(2560, 1440),
     new Vector2Int(3840, 2160)
    };

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

        dropdownResolution.ClearOptions();
        foreach (var res in resolutions)
        {
            dropdownResolution.options.Add(new TMP_Dropdown.OptionData($"{res.x}x{res.y}"));
        }

        dropdownResolution.value = GetCurrentResolutionIndex();
        dropdownResolution.RefreshShownValue();
        dropdownResolution.onValueChanged.AddListener(SetResolution);

        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxCVolumeSlider.onValueChanged.AddListener(SetSFXVolume);
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

   public void SetResolution(int index)
    {
        Screen.SetResolution(resolutions[index].x, resolutions[index].y, Screen.fullScreen);
    }

    private int GetCurrentResolutionIndex()
    {
        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].x == Screen.width && resolutions[i].y == Screen.height)
            {
                return i;
            }
        }
        return 0;
    }
    public void BackMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
