using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance;
    public EnergyBall bulletprefab;
    private int bulletsize = 5;
    private List<EnergyBall> bullets= new();
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
        }
        InicializePool();

    }
    private void InicializePool()
    {
      
        for (int i = 0; i < bulletsize; i++)
        {
            EnergyBall bullet = Instantiate(bulletprefab,this.transform);
            bullet.gameObject.SetActive(false);
            bullets.Add(bullet);
        }
    }
    public EnergyBall GetBullet()
    {
        foreach (EnergyBall bullet in bullets)
        {   
            if (!bullet.gameObject.activeInHierarchy)
            {
                return bullet;
            }
        }
        return null;
       
    }
}
