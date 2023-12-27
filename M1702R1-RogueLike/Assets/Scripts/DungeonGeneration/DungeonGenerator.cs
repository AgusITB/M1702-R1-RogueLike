using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public DungeonGenerationData dungeonGenerationData;
    private List<Vector2Int> dungeonRooms;
    private bool shopGenerated;

    private void Start()
    {
       
        dungeonRooms = DungeonCrawlerController.GenerateDungeon(dungeonGenerationData);
        SpawnRooms(dungeonRooms);
    }
    private void SpawnRooms(IEnumerable<Vector2Int> rooms)
    {
        RoomController.instance.LoadRoom("Start", 0, 0);

        foreach (Vector2Int roomLocation in rooms)
        {
            if(Random.Range(0,3)==2 && !shopGenerated)
            {
                shopGenerated = true;   
                RoomController.instance.LoadRoom("Shop", roomLocation.x, roomLocation.y);
            }else
            {
                RoomController.instance.LoadRoom("Empty", roomLocation.x, roomLocation.y);
            }
           
        }

    }


}
