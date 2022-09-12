using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2HealthController : MonoBehaviour
{
    public static Player2HealthController instance;
    public int currentHealth;
    public int maxHealth;


    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;

        UIController.instance.healthSlider.maxValue = maxHealth;
        UIController.instance.healthSlider.value = currentHealth;

        UIController.instance.healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void damagePlayer()
    {
        currentHealth--;

        if(currentHealth <= 0)
        {
            Player2Controller.instance.gameObject.SetActive(false);
            UIController.instance.deathScreen.SetActive(true);
            AudioMap.instance.playBGM(9);

        }

        UIController.instance.healthSlider.value = currentHealth;
        UIController.instance.healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
    }

    public void healPlayer(int healAmount)
    {
        currentHealth += healAmount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UIController.instance.healthSlider.value = currentHealth;
        UIController.instance.healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
    }
}
