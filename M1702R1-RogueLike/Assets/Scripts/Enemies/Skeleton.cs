using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Skeleton : Enemy
{
    SkeletonAnimations skeletonAnimations;
    public Explosion prefab;

    public float timeToExplode = 0.7f;
    public bool iWillExplode = false;
    public float distance;

    protected override void Awake()
    {
        base.Awake();
        skeletonAnimations = GetComponentInChildren<SkeletonAnimations>();
        maxHp = 15;
        currentHp = maxHp;
        speed = 2;
    }

    private void Update()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);
        if (playerIsInSameRoom & currentHp > 0 && !isDead)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            skeletonAnimations.AnimateMovement(transform.position - target.position);
        }

        if (iWillExplode)
        {  
            if (distance < 3f)
            {
                timeToExplode -= Time.deltaTime;
                AnimateHit(Color.yellow);              
            } else {
                if (timeToExplode >= 0.7f)
                {
                    timeToExplode = 0.7f;
                }
                else timeToExplode += Time.deltaTime;


            }
            if (timeToExplode <= 0)
            {
                StartCoroutine(Explosion());
            }      
        }
    }

    public override void Die()
    {
        if (isDead) return;
        base.Die();
        enemyAnimator.SetBool("isDead", isDead);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            iWillExplode = true;
        }
    }

    private IEnumerator Explosion()
    {
        AnimateHit(Color.yellow);

        yield return new WaitForSeconds(1f);
        Instantiate(prefab, this.transform.position, Quaternion.identity);
        Die();
    }




}
