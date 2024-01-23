using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownHandler : MonoBehaviour
{
    public static CooldownHandler Instance;

    [SerializeField] private List<CooldownData> abilitiesOnCooldown = new();

    [System.Serializable]
    private class CooldownData
    {
        public Ability ability;
        public float cooldown;
        public CooldownData(Ability ability, float cooldown)
        {
            this.ability = ability;
            this.cooldown = cooldown;
        }
    }
    /// <summary>
    /// Singleton
    /// </summary>
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    /// <summary>
    /// Creates cooldown data of the ability, adds it to the abilitiesOnCooldown list
    /// and executes a corotine to acomplish the cooldown.
    /// </summary>
    /// <param name="ability"></param>
    public void PutOnCooldown(Ability ability)
    {
        CooldownData abilitycd = new(ability, ability.AbilityCooldown);

        abilitiesOnCooldown.Add(abilitycd);
        StartCoroutine(Cooldown(abilitycd,ability));
    }
    /// <summary>
    /// Executes the cooldown of ability and removes it from the abilitiesOnCooldown list.
    /// </summary>
    /// <param name="ability"></param>
    /// <returns></returns>
    IEnumerator Cooldown(CooldownData CDability, Ability ability)
    {
        float maxCooldown = CDability.cooldown;
        while (CDability.cooldown > 0f)
        {
            ability.slider.UpdateSliderCooldown(CDability.cooldown, maxCooldown);
            CDability.cooldown -= Time.deltaTime;
            yield return null;
        }    
        abilitiesOnCooldown.Remove(CDability);
    }
    /// <summary>
    /// Returns a boolean that represents if the ability sent by parameters is on cooldown.
    /// </summary>
    /// <param name="ability"></param>
    /// <returns></returns>
    public bool IsOnCooldown(Ability ability)
    {
        foreach(CooldownData cooldownData in abilitiesOnCooldown)
        {
            if (cooldownData.ability == ability)
            { 
               // Debug.Log($"{ability.AbilityName} is on cooldown for another {cooldownData.cooldown} seconds");
                return true;
            }
           
        }
        return false;
    }

}
