using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    [SerializeField] private string abilityName = "New Ability Name";

    [SerializeField] private string abilityDescription = "New Ability Description";

    [SerializeField] private float abilityCooldown = 1f;


    public abstract void Cast();

}
