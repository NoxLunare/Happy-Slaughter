using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingGameController : MonoBehaviour
{
    [SerializeField] private Slider sliderLoadingGame;
    [SerializeField] private Text loadGameText;

    [SerializeField] private int loadGame = 0;

    private void FixedUpdate()
    {
        LoadingGame();
    }

    public void LoadingGame()
    {
        loadGameText.text = "Loading Game " + loadGame.ToString() + "%";
        sliderLoadingGame.value = loadGame;
        loadGame++;

        if (loadGame == 100)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
