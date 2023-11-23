using System.Collections;
using System.Collections.Generic;
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
        ConnectFloatToSlider();
        HealthController();
    }

    public void HealthController()
    {

        if (health > 100)
        {
            health = 100;
        }

        if (health <= 0)
        {
            health = 0;
            Die();
        }
    }

    public void ConnectFloatToSlider()
    {
        healthSlider.value = health;
    }

    public void Die()
    {
        Destroy(gameObject,2);
        SceneManager.LoadScene("MainMenu");
    }
}
