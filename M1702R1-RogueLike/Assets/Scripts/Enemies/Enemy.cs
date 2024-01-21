using System;
using System.Collections;
using UnityEngine;

public abstract class Enemy : Character
{
    protected bool playerIsInSameRoom;
    public Room currentRoom;
    protected Transform target;
    public GameObject monedaPrefab;

    public static Action<Enemy> die;


    private void OnEnable()
    {
        RoomController.wakeEnemiesOnThisRoom += ActivateBehaviour;
    }
    private void OnDisable()
    {
        RoomController.wakeEnemiesOnThisRoom -= ActivateBehaviour;
    }

    protected override void Awake()
    {
        base.Awake();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();  
    }

    public void SetCurrentRoom(Room room)
    {
        currentRoom = room;
    }
    
    protected void ActivateBehaviour(Room currentRoom)
    {
        playerIsInSameRoom = RoomController.instance.currentRoom == this.currentRoom;
    }

    public override void Die()
    {
        die.Invoke(this);
        base.Die();
        Instantiate(monedaPrefab, transform.position, Quaternion.identity);
        
    }

}
