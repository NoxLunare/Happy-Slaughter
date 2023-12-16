
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;
    public Slider healthSlider;

    public float health;
    public float maxHealth = 100f;

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
   
        health = maxHealth;
      
    }

  
    void Update()
    {
        HealthController();
    }

    public void HealthController()
    {
        healthSlider.value = health;

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        if (health <= 0)
        {
            health = 0;

            Die();
        }
    }


    public void Die()
    {
        Destroy(gameObject,2);
        SceneManager.LoadScene("MainMenu");
    }
}
