using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseGame : MonoBehaviour
{
    public static PauseGame Instance;

    public PlayerLookArround playerLookArround;

    public GameObject scenePauseGame;
    public GameObject playerUI;
    

    public bool isActiveMenuUI;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
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
            isActiveMenuUI = !isActiveMenuUI;
            Time.timeScale = isActiveMenuUI ? 0:1;
            Cursor.visible = isActiveMenuUI;
            playerLookArround.enabled = !isActiveMenuUI;
            scenePauseGame.SetActive(isActiveMenuUI);
            playerUI.SetActive(!isActiveMenuUI);
          
        }
    }

    public void ResumeGame()
    {
        Cursor.visible = false;
        scenePauseGame.SetActive(!isActiveMenuUI);
        playerUI.SetActive(isActiveMenuUI);
        playerLookArround.enabled = true;
        Time.timeScale = 1.0f;
    }

 

    public void BackMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
