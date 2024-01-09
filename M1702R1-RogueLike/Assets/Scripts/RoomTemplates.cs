using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{

    public GameObject[] southRooms;
    public GameObject[] westRooms;
    public GameObject[] northRooms;
    public GameObject[] eastRooms;

    public GameObject closedRoom;

    public static RoomTemplates instance;

    public List<GameObject> rooms;

    public float waitTime;
    public bool spawnedBoss= false;


    public GameObject boss;
    private void Awake()
    {
        instance = this;
    }
    public void InvocarBoss()
    {
        Instantiate(boss, rooms[rooms.Count-1].transform.position, Quaternion.identity);
        spawnedBoss = true;
    }
  



}
