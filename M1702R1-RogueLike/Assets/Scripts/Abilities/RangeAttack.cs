using UnityEngine;


public class RangeAttack : Ability
{
    public EnergyBall bulletPrefab;

    public Transform bulletDirection;

    private PlayerAnimation pAnimation;

    

    protected override void Awake()
    {
        base.Awake();
        pAnimation = GetComponent<PlayerAnimation>();
    }


    public override void Cast()
    {
        
        EnergyBall g = BulletPool.Instance.GetBullet();
        if (g == null) { return; }
        g.transform.SetPositionAndRotation(bulletDirection.transform.position, bulletDirection.rotation);
        StartCoroutine(pAnimation.Attack(this.AbilityName));
   

        var mouseDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        g.gameObject.SetActive(true);
        g.DirectionBullet(mouseDirection-transform.position);
  
    }

}
