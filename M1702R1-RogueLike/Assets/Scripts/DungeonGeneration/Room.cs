using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Room : MonoBehaviour
{

    public int Width;
    public int Height;

    public int X { get; set; }
    public int Y { get; set; }


    public Door leftDoor, rightDoor, topDoor, bottomDoor;

    public List<Door> doors = new();

    private bool updatedDoors = false;

    public double distance = double.MinValue;
    public bool visited = false;

    private double DistanceFromOrigin(int X, int Y)
    {
        int x = X;
        int y = Y;
        return Math.Sqrt(x * x + y * y);
    }

    private void Update()
    {
        if (name.Contains("End") && !updatedDoors)
        {
            RemoveUnconnectedDoors();
            updatedDoors = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (RoomController.instance == null)
        {
            Debug.Log("You pressed play in the wrong scene!");
            return;
        }
        Door[] ds = GetComponentsInChildren<Door>();
        foreach (Door d in ds)
        {
            doors.Add(d);
            switch (d.doorType)
            {
                case Door.DoorType.right:
                    rightDoor = d;
                    break;
                case Door.DoorType.top:
                    topDoor = d;
                    break;
                case Door.DoorType.bottom:
                    bottomDoor = d;
                    break;
                case Door.DoorType.left:
                    leftDoor = d;
                    break;
            }
        }
        RoomController.instance.RegisterRoom(this);
        distance = DistanceFromOrigin(X, Y);
        GetEnemiesRoom();
    }


    public void GetEnemiesRoom()
    {
        Enemy[] enemies = GetComponentsInChildren<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            enemy.SetCurrentRoom(this);
        }
        if(name.Contains("Empty")) InstantiateEnemies();

    }

    private void InstantiateEnemies()
    {
        System.Random rand = new System.Random();
        int room = rand.Next(0, RoomController.instance.RoomsSO.roomPrefabs.Count);
        Instantiate(RoomController.instance.RoomsSO.roomPrefabs[room],this.gameObject.transform);
    }
    public void RemoveUnconnectedDoors()
    {
        foreach (Door door in doors)
        {
            switch (door.doorType)
            {
                case Door.DoorType.right:
                    if (GetRight() == null)
                        door.gameObject.SetActive(false);
                    break;
                case Door.DoorType.top:
                    if (GetTop() == null)
                        door.gameObject.SetActive(false);
                    break;
                case Door.DoorType.bottom:
                    if (GetBottom() == null)
                        door.gameObject.SetActive(false);
                    break;
                case Door.DoorType.left:
                    if (GetLeft() == null)
                        door.gameObject.SetActive(false);
                    break;
            }
        }
    }

    public Room GetRight()
    {
        if (RoomController.instance.DoesRoomExist(X + 1, Y))
        {
            return RoomController.instance.FindRoom(X + 1, Y);
        }
        return null;
    }
    public Room GetLeft()
    {
        if (RoomController.instance.DoesRoomExist(X - 1, Y))
        {
            return RoomController.instance.FindRoom(X - 1, Y);
        }
        return null;
    }
    public Room GetTop()
    {
        if (RoomController.instance.DoesRoomExist(X, Y + 1))
        {
            return RoomController.instance.FindRoom(X, Y + 1);
        }
        return null;
    }
    public Room GetBottom()
    {
        if (RoomController.instance.DoesRoomExist(X, Y - 1))
        {
            return RoomController.instance.FindRoom(X, Y - 1);
        }
        return null;
    }

    public Vector3 GetRoomCenter()
    {
        return new Vector3(X * Width, Y * Height);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(Width, Height, 0));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            RoomController.instance.OnPlayerEnterRoom(this);
        }
    }
}
