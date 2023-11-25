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
    public void Attack()
    {
        var mouseDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //mouseDirection.Normalize();

        Bullet g = Instantiate(bullet, bulletDirection.transform.position, bulletDirection.rotation);

        Debug.Log("Se ha activado la bala");

        g.gameObject.SetActive(true);
        g.DirectionBullet(mouseDirection);
    }


    //IEnumerator CanShoot()
    //{
    //    canShoot = false;
    //    yield return new WaitForSeconds(2f);
    //    canShoot = true;
    //}

}
