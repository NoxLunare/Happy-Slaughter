using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseGame : MonoBehaviour
{
    public PlayerLookArround playerLookArround;

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
            playerLookArround.enabled = !isActive;
            scenePauseGame.SetActive(isActive);
            playerUI.SetActive(!isActive);
        }
    }

    public void ResumeGame()
    {
        Cursor.visible = false;
        scenePauseGame.SetActive(!isActive);
        playerUI.SetActive(isActive);
        playerLookArround.enabled = true;
        Time.timeScale = 1.0f;
    }

    public void BackMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
