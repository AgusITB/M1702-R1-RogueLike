using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Character, IDamagable
{

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
        
    }

    public void Die()
    {
        
    }

    public void TakeDamage(int damage)
    {
        
    }
}
