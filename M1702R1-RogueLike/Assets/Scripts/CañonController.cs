using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CañonController : Ability 
{ 
    public GameObject bullet;
    public Transform bulletDirection;
    private float timer;
    private GameObject player;



    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {

        float distance= Vector2.Distance(transform.position,player.transform.position);

        //Debug.Log(distance);

        if(distance < 10)
        {
            RotateTowards();
            Attack();
        }
    }
    protected virtual void Attack()
    {
        if (CooldownHandler.Instance.IsOnCooldown(this)) { return; }
        Cast();
        CooldownHandler.Instance.PutOnCooldown(this);
    }

    private void RotateTowards()
    {
        var playerPos = player.transform.position;
        var position = transform.position;

        float angle = Mathf.Atan2(playerPos.y - position.y, playerPos.x - position.x) * Mathf.Rad2Deg - 90f;

        Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);

        transform.rotation = targetRotation;
    }
    public override void Cast()
    {  
        Instantiate(bullet,bulletDirection.position,Quaternion.identity);
        EnemyBulletCañon.instance.Shoot();
    }

}
