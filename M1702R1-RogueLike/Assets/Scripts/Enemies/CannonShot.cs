using UnityEngine;


public class CannonShot : Ability 
{ 
    public GameObject bullet;
    public Transform bulletDirection;
    public static CannonShot instance;

    public virtual void Attack()
    {
        if (CooldownHandler.Instance.IsOnCooldown(this)) { return; }
        Cast();
        CooldownHandler.Instance.PutOnCooldown(this);
    }
    public override void Cast()
    {  
        Instantiate(bullet,bulletDirection.position,Quaternion.identity);
        CannonBullet.instance.Shoot();
    }

}
