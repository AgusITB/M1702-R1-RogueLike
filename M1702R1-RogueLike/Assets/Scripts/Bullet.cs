using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class Bullet : MonoBehaviour
{

    private Stack<GameObject> stack;
    public GameObject balaPrefab; // Prefab de la bala
    public Transform Player; // Transform para el punto de disparo
    public float tiempoEntreDisparos = 1.0f;


    private float tiempoUltimoDisparo;
    public static Bullet Instance;

    void Start()
    {
        stack = new Stack<GameObject>();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstaculo"))
        {

            Destroy(other.gameObject);
        }
    }

    void Update()
    {
        if (Time.time - tiempoUltimoDisparo >= tiempoEntreDisparos)
        {
            tiempoUltimoDisparo = Time.time;
           
        }
    }

    public void Disparar(InputAction.CallbackContext context)
    {

        if (stack.Count > 0)
        {
            GameObject bala = stack.Pop();
            bala.transform.position = Player.position;
            bala.transform.rotation = Player.rotation;
            bala.SetActive(true);
            //Debug.Log("Se ha disparado");
        }
    }
    
    public void Push(GameObject go)
    {
        stack.Push(go);
        go.SetActive(false);
        Debug.Log("Se ha Desactivado");
    }
    public void Pop()
    {
        if (stack.Count > 0)
        {
            stack.Pop().SetActive(true);
        }
        else
        {
            Debug.Log("La pila est� vac�a.");
        }
    }

    public void Peek()
    {
        if (stack.Count > 0)
        {
            Debug.Log("Elemento en la cima de la pila: " + stack.Peek());
        }
        else
        {
            Debug.Log("La pila est� vac�a.");
        }
    }

}

