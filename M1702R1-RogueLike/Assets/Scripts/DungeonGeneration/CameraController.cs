using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class CameraController : MonoBehaviour
{

    public static CameraController Instance;

    public Room currentRoom;
    public Room lastRoom;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    public float moveSpeedWhenRoomChange;

    

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }

    public void UpdatePosition()
    {
        if (currentRoom == null) return;

        Vector3 targetPos = GetCameraTargetPosition();
        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * moveSpeedWhenRoomChange); 
    }
    Vector3 GetCameraTargetPosition()
    {
        if (currentRoom == null)
        {
            return Vector3.zero;
        }
        Vector3 targetPos = currentRoom.GetRoomCenter();
        targetPos.z = transform.position.z;

        return targetPos;
    }
    public bool IsSwitchingScene()
    {
        return transform.position.Equals(GetCameraTargetPosition())==false;
    }

}
