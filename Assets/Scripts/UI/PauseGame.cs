using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseGame : MonoBehaviour
{
    public GameObject scenePauseGame;
    public GameObject playerUI;

    public bool isActive;

    private void Start()
    {
        Time.timeScale = 1.0f;
    }
    private void Update()
    {
        PauseGameController();
      
    }
    public void PauseGameController()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isActive = !isActive;
            Time.timeScale = isActive ? 0:1;
            Cursor.visible = isActive;
            scenePauseGame.SetActive(isActive);
            playerUI.SetActive(!isActive);
        }
    }

    public void ResumeGame()
    {
        Cursor.visible = false;
        scenePauseGame.SetActive(!isActive);
        playerUI.SetActive(isActive);
        Time.timeScale = 1.0f;
    }

    public void BackMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
