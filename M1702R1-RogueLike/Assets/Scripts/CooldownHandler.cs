using System.Collections;
using System.Collections.Generic;
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

    private void Update()
    {
        for (int i = 0; i <abilitiesOnCooldown.Count; i++)
        {
            abilitiesOnCooldown[i].cooldown -= Time.deltaTime;
        }

        for (int i = abilitiesOnCooldown.Count - 1; i >= 0; i--)
        {
            if (abilitiesOnCooldown[i].cooldown <= 0)
            {
                abilitiesOnCooldown.RemoveAt(i);
            }
        }
    }
    public void PutOnCooldown(Ability ability)
    {
        abilitiesOnCooldown.Add(new CooldownData(ability, ability.AbilityCooldown));
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
