using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.CompareTag("Player"))
        //{
        //    if (SceneManager.GetActiveScene().name == "BasementMain")
        //    {
        //        DontDestroyOnLoad(CooldownHandler.Instance);
        //        DontDestroyOnLoad(Player.Instance);
        //        SceneManager.LoadScene("BasementMain2");
        //        collision.gameObject.transform.position = Vector3.zero;
        //    }
       
        //}


    }
}
