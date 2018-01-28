using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Map : MonoBehaviour
{
    public static Map Instance;

    public Room currentRoom;

    private List<Room> rooms = new List<Room>();
    private List<Door> doors = new List<Door>();

    public GameObject Player1;
    public GameObject Player2;

    public delegate void InitFinished();

    public event InitFinished OnInitFinished;

    // Use this for initialization
    void Start()
    {
        Instance = this;
        LoadChildDoors();
        LoadChildRooms();
    }

    // Update is called once per frame
    void Update()
    {
        // mozda nesto
    }


    // 

    void Init()
    {

    }

    void LoadChildRooms()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Room room = transform.GetChild(i).GetComponent<Room>();
            if (room != null)
                rooms.Add(room);
        }
    }

    void LoadChildDoors()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Door door = transform.GetChild(i).GetComponent<Door>();
            if (door != null)
                doors.Add(door);
        }
    }
}