using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CooldownHandler : MonoBehaviour
{
    public static CooldownHandler Instance;

    [SerializeField] private List<CooldownData> abilitiesOnCooldown = new List<CooldownData>();

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
    public void PutOnCooldown(Ability ability)
    {
        CooldownData abilitycd = new CooldownData(ability, ability.AbilityCooldown);

        abilitiesOnCooldown.Add(abilitycd);
        StartCoroutine(Cooldown(abilitycd));
    }

    IEnumerator Cooldown(CooldownData ability)
    {
        while (ability.cooldown > 0f)
        {
            ability.cooldown -= Time.deltaTime;
            yield return null;
        }
        //yield return new WaitForSeconds(ability.cooldown);
        abilitiesOnCooldown.Remove(ability);
    }

    public bool IsOnCooldown(Ability ability)
    {
        foreach(CooldownData cooldownData in abilitiesOnCooldown)
        {
            if (cooldownData.ability == ability)
            {
                Debug.Log($"{ability.AbilityName} is on cooldown for another {cooldownData.cooldown} seconds");
                return true;
            }
           
        }
        return false;
    }

}
