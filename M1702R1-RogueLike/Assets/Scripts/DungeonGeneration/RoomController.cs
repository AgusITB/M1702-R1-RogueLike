using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Unity.VisualScripting;
using UnityEditor;
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

    bool spawnedBossRoom = false;

    bool updatedRooms = false;

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
            if (!spawnedBossRoom)
            {
                StartCoroutine(SpawnBossRoom());
            }
            else if (spawnedBossRoom && !updatedRooms)
            {
                foreach (Room room in loadedRooms)
                {
                    room.RemoveUnconnectedDoors();
                }
                updatedRooms = true;
            }
            return;
        }
        currentLoadRoomData = loadRoomQueue.Dequeue();
        isLoadingRoom = true;
        StartCoroutine(LoadRoomRoutine(currentLoadRoomData));
    }

    /// <summary>
    /// Funcion que espera 0.5 segundos para comprobar si ya se han generado todas las habitaciones,
    /// si ya no queda ninguna habitación en la cola, buscamos la ultima habitación generada de la lista,
    /// destruimos dicha habitacion y la borramos de la lista y finalmente generamos la 
    /// habitación de tipo Boss en su lugar.
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnBossRoom()
    {
        spawnedBossRoom = true;
        yield return new WaitForSeconds(0.5f);
        if (loadRoomQueue.Count == 0)
        {

            //Room bossRoom = loadedRooms[^1];
            Room bossRoom = GetFarthestRoom();
            Vector2Int tempRoom = new(bossRoom.X, bossRoom.Y);
            Destroy(bossRoom.gameObject);
            var roomToRemove = loadedRooms.Single(r => r.X == tempRoom.x && r.Y == tempRoom.y);
            loadedRooms.Remove(roomToRemove);
            LoadRoom("End", tempRoom.x, tempRoom.y);
        }
    }


    private Room GetFarthestRoom()
    {
        if (loadedRooms.Count == 0)
        {
            // Handle the case when there are no rooms loaded
            return null; // or throw an exception, log a message, etc.
        }

        Room farthestRoom = loadedRooms[0];
        foreach (Room room in loadedRooms)
        {
            if (room.distance > farthestRoom.distance)
            {
                farthestRoom = room;
            }
        }
        return farthestRoom;
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
    public Room FindRoom(int x, int y)
    {
        return loadedRooms.Find(room => room.X == x && room.Y == y);
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