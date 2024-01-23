using UnityEngine;
public class Cannon : Enemy
{

    public GameObject bullet;
    public Transform bulletDirection;
    private CannonShot cannonShoot;

    protected override void Awake()
    {
        base.Awake();
        cannonShoot = GetComponent<CannonShot>();  
    }
    private void Update()
    {
        if (target == null) { return; }
        float distance = Vector2.Distance(transform.position, target.transform.position);

        if (distance < 10 && !isDead && playerIsInSameRoom)
        {
            RotateTowards();
            cannonShoot.Attack();
        }
    }
    private void RotateTowards()
    {
        var playerPos = target.transform.position;
        var position = transform.position;

        float angle = Mathf.Atan2(playerPos.y - position.y, playerPos.x - position.x) * Mathf.Rad2Deg - 90f;

        Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);

        transform.rotation = targetRotation;
    }


}

