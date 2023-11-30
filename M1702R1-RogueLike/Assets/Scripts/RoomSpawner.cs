using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{

    public int openingDirection;


    private RoomTemplates templates;
    private int rand;

    GameObject[] templateArray;

    private bool spawned = false;


    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        templateArray = ChooseArray();
        Invoke("SpawnRoom", 0.5f);
    }


    GameObject[] ChooseArray()
    {

        if (openingDirection == 1)  return templates.northRooms; 
        else if (openingDirection == 2) return templates.eastRooms;
        else if (openingDirection == 3) return templates.southRooms; 
        else if (openingDirection == 4) return templates.westRooms; 

        return null;
    }
    void SpawnRoom()
    {
        if (spawned == false)
        {
            rand = Random.Range(0,templateArray.Length);
            Instantiate(templateArray[rand], transform.position, templateArray[rand].transform.rotation);
        }
        spawned = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint"))
        {   
            if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                // Spawn walls 
                Destroy(this);
            }
            spawned = true;
        }
    }



}
