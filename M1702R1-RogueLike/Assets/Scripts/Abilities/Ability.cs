using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Ability : MonoBehaviour
{
    [SerializeField] private string abilityName = "New Ability Name";

    [SerializeField] private string abilityDescription = "New Ability Description";

    [SerializeField] private float abilityCooldown = 1f;

    public CooldownSlider slider;

    private PlayerControls playerControls;

    //Getters
    public float AbilityCooldown { get { return abilityCooldown; } }

    public string AbilityDescription { get { return abilityDescription; } }

    public string AbilityName { get { return abilityName; } }

    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }
    protected virtual void Awake()
    {
        playerControls = new PlayerControls();

        if (abilityName == "MeleeAttack")
            playerControls.Gameplay.Attack.performed += Attack;

        if (abilityName == "RangeAttack")
            playerControls.Gameplay.RangeAttack.performed += Attack;
        if (abilityName == "FlameThrower")
            playerControls.Gameplay.FlameThrower.performed += Attack;
    }
    protected virtual void Attack(InputAction.CallbackContext context)
    {
        if(CooldownHandler.Instance.IsOnCooldown(this)) { return; }
       // Debug.Log($"I am casting: {abilityName}");
        Cast();
        CooldownHandler.Instance.PutOnCooldown(this);
    }

    public abstract void Cast();


}
