using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class ParticleController : Ability
{
    public new ParticleSystem particleSystem;

    protected override void Awake()
    {
        base.Awake();
        particleSystem = GetComponent<ParticleSystem>();
    }

    void Start()
    {

        // Change the start rotation
        ParticleSystem.MainModule mainModule = particleSystem.main;
        mainModule.startRotation = 0;
    }
    public override void Cast()
    {
        particleSystem.transform.position = transform.position;
       // Debug.Log(particle.transform.position);
        var mouseDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mouseDirection - transform.position);
        direction.Normalize();

        // Calcula el ángulo en radianes
        float rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        ParticleSystem.MainModule mainModule = particleSystem.main;
        mainModule.startRotation = 0;

        //rotación al sistema de partículas
        particleSystem.transform.rotation = Quaternion.Euler(0, 0, rotation);
        particleSystem.Play();

        StartCoroutine(StopParticleSystem());
    }
    IEnumerator StopParticleSystem()
    {
        yield return new WaitForSeconds(10f);
        particleSystem.Stop();
    }
}

