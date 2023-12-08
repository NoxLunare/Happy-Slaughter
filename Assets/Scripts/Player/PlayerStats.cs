
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour
{
    public Slider healthSlider;

    public float health;
    public float maxHealth = 100f;
 
    

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
