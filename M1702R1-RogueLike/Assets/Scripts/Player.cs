using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : Character, IDamagable, ICoinCollectible
{
    public Text coinsText;
    private int totalCoins = 0;

    private PlayerInputs playerinput;
    private PlayerAnimation playerAnimation;
    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerinput = GetComponent<PlayerInputs>();
        playerAnimation = GetComponent<PlayerAnimation>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void AnimateHit()
    {
        // Lógica de animación de golpe
    }

    public void Die()
    {
        // Lógica de muerte del jugador
    }

    public void TakeDamage(int damage)
    {
        // Lógica para reducir la salud del jugador
    }

    public void CollectCoins(int coinValue)
    {
        totalCoins += coinValue;
        Debug.Log("Recogidas " + coinValue + " puntos. Total: " + totalCoins + " monedas ");
        UpdateCoinsText(totalCoins);
    }

    private void UpdateCoinsText(int value)
    {
        if (coinsText != null)
        {
            coinsText.text = " + " + value.ToString();
        }
    }
}
