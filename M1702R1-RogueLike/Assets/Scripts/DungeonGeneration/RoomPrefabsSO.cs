using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New rooms", menuName = "Rooms/Create rooms")]

public class RoomPrefabsSO : ScriptableObject
{
  public List<GameObject> roomPrefabs = new(); 
}
