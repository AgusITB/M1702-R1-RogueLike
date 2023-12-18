using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class ParticleController : Ability
{
    public ParticleSystem particle;
    private bool isMousePressed = false;

    void Update()
    {




        //isMousePressed = false;
        //particle.Stop();

    }

    public override void Cast()
    {
        particle.transform.position = transform.position;
        Debug.Log(particle.transform.position);
        var mouseDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mouseDirection - transform.position);
        direction.Normalize();

        // Calcula el ángulo en radianes
        float rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //rotación al sistema de partículas
        particle.transform.rotation = Quaternion.Euler(0, 0, rotation);
        particle.Play();

        StartCoroutine(StopParticleSystem());
    }
    IEnumerator StopParticleSystem()
    {
        yield return new WaitForSeconds(2f);
        particle.Stop();
    }
}

