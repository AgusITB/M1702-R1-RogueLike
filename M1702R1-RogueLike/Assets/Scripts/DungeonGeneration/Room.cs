using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    public int Width;
    public int Height;

    public int X { get; set; }
    public int Y { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        if (RoomController.instance == null) {
            Debug.Log("You pressed play in the wrong scene!");
            return;
        }
        RoomController.instance.RegisterRoom(this);
    }

    public Vector3 GetRoomCenter()
    {
        return new Vector3 (X * Width, Y * Height);
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
           // CameraController.instance.UpdatePosition();
            RoomController.instance.OnPlayerEnterRoom(this);
            
        }
    }
}
