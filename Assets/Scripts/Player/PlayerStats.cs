using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    public Slider healthSlider;
    public Slider expSlider;
    public Slider overheatingSlider;

    public Text levelPlayerText;
    public Text scrapText;

    public GameObject fire;

    public float currentHealth;
    public float maxHealth = 100f;
    public float overheating = 0;

    public int currentExp;
    public int maxExp;
    public int scrap;
    public int levelPlayer;

  
    private bool isBurningSoundPlayer = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        currentHealth = maxHealth;
   
    }

  
    void Update()
    {
        HealthController();
        ExpController();
        OverheatingController();    
    }

    public void HealthController()
    {
        healthSlider.value = currentHealth;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
     
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0;

            Die();
        }

        if (currentHealth < maxHealth)
        {
            SaveManager.Instance.SavePlayerStats();
        }
    }
    public void ExpController()
    {
        if (currentExp >= maxExp)
        {
            levelPlayer++;
            maxExp += 2;           
            currentExp = 0;
            SaveManager.Instance.SavePlayerStats();
        }
    }

    public void OverheatingController()
    {
        overheatingSlider.value = overheating;

        if (overheating <= 0)
        {
            overheating = 0;
        }
        else if (overheating >= 100)
        {
            overheating = 100;

        }


        if (overheating >= 80)
        {
            currentHealth -= 0.003f;
           
            fire.SetActive(true);

            if (!isBurningSoundPlayer)
            {
                AudioManager.Instance.StartBurningPlayerSound();
                isBurningSoundPlayer = true;
            }
        }

        if (overheating < 80)
        {
            fire.SetActive(false);
         

            if (isBurningSoundPlayer)
            {
                AudioManager.Instance.StopBurningPlayerSound();
                isBurningSoundPlayer = false;
            }
        }

        if (overheating <= 100)
        {
            overheating -= 0.030f;
        }

       
    }
    public int GetExp(int exp)
    {
        currentExp += exp;
        SaveManager.Instance.SavePlayerStats();
        return exp;
    }
    public int GetScrap(int scrap)
    {
        this.scrap += scrap;
        SaveManager.Instance.SavePlayerStats();
        return scrap;
    }

    public int GetOverheating(int overheating)
    {
        this.overheating += overheating;
        SaveManager.Instance.SavePlayerStats();
        return overheating; 
    }

    public void UpdateScrapUI()
    {
        scrapText.text = scrap.ToString();
    }
    public void UpdateExpUI()
    {
        expSlider.value = currentExp;
        expSlider.maxValue = maxExp;
        levelPlayerText.text = levelPlayer.ToString();
    }
    public void Die()
    {
        PlayerPrefs.DeleteAll();
        Destroy(gameObject,2);
        SceneManager.LoadScene("MainMenu");
    }
}
