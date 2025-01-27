using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerhealth : MonoBehaviour
{
    public float health, maxHealth;

    public Slider healthSlider;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthSlider.maxValue = health;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = health;
        if(health <= 0)
        {
            health = maxHealth;
            GameOver();
        }
        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }

    void GameOver ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
