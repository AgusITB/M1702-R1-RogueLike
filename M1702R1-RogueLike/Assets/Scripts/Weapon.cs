using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Weapon : MonoBehaviour
{
    public GameObject meleePrefab;
    GameObject meleeSlash;

    private void Awake()
    {
        Vector3 position = new (transform.position.x, transform.position.y);


        meleeSlash = Instantiate(meleePrefab, position, Quaternion.identity);

        meleeSlash.transform.SetParent(this.transform, true);
        meleeSlash.SetActive(false);
    }

    public IEnumerator Attack()
    {
        meleeSlash.SetActive(true);
        yield return new WaitForSeconds(0.583f);
        meleeSlash.SetActive(false);

    }


}




