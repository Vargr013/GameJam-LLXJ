using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public TMP_Text healthBarText;   
    Damageable playerDamageable;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        healthSlider.value = CalculateSliderPercentage(playerDamageable.CurrentHealth, playerDamageable.MaxHealth);
        healthBarText.text = "HP " + playerDamageable.CurrentHealth + "/" + playerDamageable.MaxHealth;
    }

    private float CalculateSliderPercentage(float currentHealth, float maxHealth)
    {
        return currentHealth / maxHealth;
    }

    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerDamageable = player.GetComponent<Damageable>();
    }

}
