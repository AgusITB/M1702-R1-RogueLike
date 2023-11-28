using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Character, IDamagable
{
    EnemyHealthBar healthBar;
    SpriteRenderer spriteRenderer;
    Color defaultColor;
    Animator enemyAnimator;
    Color dieColor;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        healthBar = GetComponentInChildren<EnemyHealthBar>();
        enemyAnimator = GetComponent<Animator>();

        dieColor = defaultColor;
        maxHp = 15;
        speed = 2;
        currentHp = maxHp;
        defaultColor = spriteRenderer.color;
    }
    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        if (currentHp <= 0) currentHp = 0;

        Debug.Log($"I took damage, my hp is :{currentHp}");

        healthBar.UpdateHealthBar(currentHp, maxHp);

        if (currentHp <= 0) Die();

    }
    public void AnimateHit()
    {
      
        StartCoroutine(Flash());
        spriteRenderer.color = Color.red;
    }
    public void Die()
    {
        enemyAnimator.SetBool("isDead", true);
        dieColor.a = 0;
        StartCoroutine(Despawn(defaultColor, dieColor, 1f));

    }
    public IEnumerator Flash()
    {
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = defaultColor;
    }

    IEnumerator Despawn(Color start, Color end, float duration)
    {
        for (float t = 0f; t < duration; t += Time.deltaTime)
        {
            float normalizedTime = t / duration;
            //right here, you can now use normalizedTime as the third parameter in any Lerp from start to end
            spriteRenderer.color = Color.Lerp(start, end, normalizedTime);
            yield return null;
        }
        spriteRenderer.color = end; //without this, the value will end at something like 0.9992367

        this.gameObject.SetActive(false);
    }


}
