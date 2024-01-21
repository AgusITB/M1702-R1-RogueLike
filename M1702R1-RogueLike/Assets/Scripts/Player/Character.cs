using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour, IDamagable
{

    public bool isDead = false;
    protected int maxHp;
    protected int currentHp;
    protected int speed;
    protected EnemyHealthBar healthBar;
    protected SpriteRenderer spriteRenderer;
    protected BoxCollider2D boxCollider;
    protected Color defaultColor;
    protected Color dieColor;
    protected Animator enemyAnimator;


    protected virtual void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        healthBar = GetComponentInChildren<EnemyHealthBar>();
        enemyAnimator = GetComponent<Animator>();
        dieColor = defaultColor;
        defaultColor = spriteRenderer.color;
    }
    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHp -= damage;
        if (currentHp <= 0) currentHp = 0;

        healthBar.UpdateHealthBar(currentHp, maxHp);

        if (currentHp <= 0) Die();

    }
    public virtual void AnimateHit()
    {
        StartCoroutine(Flash());
        spriteRenderer.color = Color.red;
    }
    public virtual void AnimateHit(Color color)
    {
        StartCoroutine(Flash());
        spriteRenderer.color = color;
    }
    public virtual void Die()
    {
        isDead = true;
        StopAllCoroutines(); // Detener todas las coroutines activas

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
        yield return new WaitForSeconds(0.5f);
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
