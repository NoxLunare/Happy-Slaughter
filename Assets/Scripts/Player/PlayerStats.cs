using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour
{
    public Slider healthSlider;
    public float health;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ConnectFloatToSlider();
        HealthController();
    }

    public void HealthController()
    {
        healthSlider.value = health;

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

    }
}