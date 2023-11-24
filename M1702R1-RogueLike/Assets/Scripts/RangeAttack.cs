using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class RangeAttack : MonoBehaviour
{
    public Bullet bullet;

    public Transform bulletDirection;

    public void Attack(Vector3 mousePosition)
    {
        var mouseDirection = mousePosition - transform.position;
        mouseDirection.Normalize();

        Bullet g = Instantiate(bullet, mouseDirection, bulletDirection.rotation);

        Debug.Log("Se ha activado la bala");

        g.gameObject.SetActive(true);
        g.DirectionBullet(mousePosition);
 

    }


    //IEnumerator CanShoot()
    //{
    //    canShoot = false;
    //    yield return new WaitForSeconds(2f);
    //    canShoot = true;
    //}

}
