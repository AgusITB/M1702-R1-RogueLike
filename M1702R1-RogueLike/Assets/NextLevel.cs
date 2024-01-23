using System.Collections;
using UnityEngine;


public class NextLevel : MonoBehaviour
{
    public RoomController prefab;
    public static NextLevel Instance;

    private void Awake()
    {
        Instance = this;
        this.transform.SetParent(GameObject.FindGameObjectWithTag("PortalParent").transform, true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            RoomController.instance.loadedRooms.Clear();
            Destroy(GameObject.FindGameObjectWithTag("RoomController"));
            collision.gameObject.transform.position = Vector3.zero;
            StartCoroutine(StartNewLevel());
        }
    }

    private IEnumerator StartNewLevel()
    {
        yield return new WaitForSeconds(1.0f);
        Instantiate(prefab);
        yield return new WaitForSeconds(1.0f);
        this.gameObject.SetActive(false);

    
    }

}

