using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class RangeAttack : Ability
{
    public EnergyBall bulletPrefab;

    public Transform bulletDirection;


    public override void Cast()
    {
        var mouseDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        EnergyBall g = Instantiate(bulletPrefab, bulletDirection.transform.position, bulletDirection.rotation);

        Debug.Log("Se ha activado la bala");

        g.gameObject.SetActive(true);
        g.DirectionBullet(mouseDirection-transform.position);
  
    }

}
