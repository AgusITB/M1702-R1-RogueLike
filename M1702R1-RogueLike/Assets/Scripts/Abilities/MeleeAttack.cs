using UnityEngine;


public class MeleeAttack : Ability
{
    public GameObject meleePrefab;

    GameObject instantiatedPrefab;

    public Transform rangePosition;
    public Transform meleeParent;
    private PlayerAnimation pAnimation;


    protected override void Awake()
    {   
        base.Awake();
        pAnimation = GetComponent<PlayerAnimation>();
        Vector3 position = new (rangePosition.position.x, rangePosition.position.y );
        instantiatedPrefab = Instantiate(meleePrefab, position, Quaternion.identity);
        instantiatedPrefab.transform.SetParent(meleeParent, true);
        instantiatedPrefab.SetActive(false);
    }
    public override void Cast()
    {
        StartCoroutine(pAnimation.Attack(this.AbilityName));
        pAnimation.GetAttackDirection(PlayerInputs.Instance.direction, PlayerInputs.Instance.lastMoveDirection);
        instantiatedPrefab.SetActive(true);
    }
    


}




