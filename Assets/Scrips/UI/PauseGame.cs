using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseGame : MonoBehaviour
{
    public GameObject scenePauseGame;

    public bool isActive;

    private void Update()
    {
        PauseGameController();
    }
    public void PauseGameController()
    {
        isActive = !isActive;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            scenePauseGame.SetActive(isActive);
        }
    }

    public void ResumeGame()
    {
        scenePauseGame.SetActive(!isActive);
    }

    public void BackMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
