using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RoomInfo
{
    public string name;
    public int x, y;
    
    public RoomInfo(string name, int x, int y)
    {

        this.name = name;
        this.x = x;
        this.y = y;
    }
}
public class RoomController : MonoBehaviour
{
    private readonly float movePlayerDistance = 5f;
    public static RoomController instance;

    readonly string currentWorldName = "Basement";

    RoomInfo currentLoadRoomData;

    readonly Queue<RoomInfo> loadRoomQueue = new();

    public List<Room> loadedRooms = new();

    bool isLoadingRoom = false;

    //public Room currentRoom;

    Player player;

    void Awake()
    {
        player = FindObjectOfType<Player>();
        instance = this;
    }
    private void Update()
    {
        UpdateRoomQueue();
    }
    void UpdateRoomQueue()
    {
        if (isLoadingRoom)
        {
            return;
        }
        if (loadRoomQueue.Count == 0)
        {
            return;
        }
        currentLoadRoomData = loadRoomQueue.Dequeue();
        isLoadingRoom = true;
        StartCoroutine(LoadRoomRoutine(currentLoadRoomData));
    }
    public void LoadRoom(string name, int x, int y)
    {
        if (DoesRoomExist(x, y))
        {
            return;
        }

        RoomInfo roomData = new(name, x, y);

        loadRoomQueue.Enqueue(roomData);

    }

    IEnumerator LoadRoomRoutine(RoomInfo info)
    {
        string roomName = currentWorldName + info.name;
        AsyncOperation loadRoom = SceneManager.LoadSceneAsync(roomName, LoadSceneMode.Additive);
        while (loadRoom.isDone == false) { yield return null; }
    }
    public void RegisterRoom(Room room)
    {
        if (!DoesRoomExist(currentLoadRoomData.x, currentLoadRoomData.y))
        {
            room.transform.position = new Vector3(
            currentLoadRoomData.x * room.Width,
            currentLoadRoomData.y * room.Height,
            0
            );

            room.X = currentLoadRoomData.x;
            room.Y = currentLoadRoomData.y;
            room.name = currentWorldName + "-" + currentLoadRoomData.name + " " + room.X + ", " + room.Y;
            room.transform.parent = transform;

            isLoadingRoom = false;

            if (loadedRooms.Count == 0)
            {
                CameraController.instance.currentRoom = room;
            }

            loadedRooms.Add(room);
        }
        else
        {
            Destroy(room.gameObject);
            isLoadingRoom = false;
        }

    }

    public bool DoesRoomExist(int x, int y)
    {
        return loadedRooms.Find(room => room.X == x && room.Y == y) != null;
    }

    public void OnPlayerEnterRoom(Room room)
    {
        if (CameraController.instance.currentRoom.X > room.X)
            player.transform.position = new Vector3(player.transform.position.x - movePlayerDistance, player.transform.position.y);
        else if (CameraController.instance.currentRoom.X < room.X)
            player.transform.position = new Vector3(player.transform.position.x + movePlayerDistance, player.transform.position.y);
        else if (CameraController.instance.currentRoom.Y > room.Y)
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - movePlayerDistance);
        else if (CameraController.instance.currentRoom.Y < room.Y)
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + movePlayerDistance);

        CameraController.instance.currentRoom = room;
        // currentRoom = room;

    }

}
