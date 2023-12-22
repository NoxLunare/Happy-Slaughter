using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    public Slider healthSlider;
    public Slider expSlider;

    public Text levelPlayerText;
    public Text scrapText;

    public float currentHealth;
    public float maxHealth = 100f;

    public int currentExp;
    public int maxExp;
    public int scrap;
    public int levelPlayer;
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
    }
    public void ExpController()
    {
        if (currentExp >= maxExp)
        {
            levelPlayer++;
            maxExp += 2;           
            currentExp = 0;
            SaveManager.Instance.Save();
        }
    }
    public int GetExp(int exp)
    {
        currentExp += exp;
        return exp;
    }
    public int GetScrap(int scrap)
    {
        this.scrap += scrap;
        return scrap;
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
        Destroy(gameObject,2);
        SceneManager.LoadScene("MainMenu");
    }
}
