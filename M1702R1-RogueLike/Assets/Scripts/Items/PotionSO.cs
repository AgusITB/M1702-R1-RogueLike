using UnityEngine;

[CreateAssetMenu(fileName = "New Potion", menuName = "Items/Create potion")]
public class PotionSO : ItemSO
{
    public int healingAmount;

    protected override void Use()
    {
        Player.Instance.HealHp(healingAmount);
        consumeItem.Invoke(this);
    }
}
