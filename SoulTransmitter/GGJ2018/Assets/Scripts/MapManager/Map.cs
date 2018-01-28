using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Map : MonoBehaviour {
    public static Map Instance;

	public Room startRoom;
	public Room exitRoom;
    public Room currentRoom;

	private List<Room> rooms = new List<Room>();
    private List<Door> doors = new List<Door>();

	public delegate void InitFinished();

	public event InitFinished OnInitFinished;

	// Use this for initialization
	void Start () {
        Instance = this;
        LoadChildDoors();
        LoadChildRooms();
        Link();
	}
	
	// Update is called once per frame
	void Update () {
		// mozda nesto
	}


	// 

	void Init(){
		
	}

    public void EnableDoors(){
        foreach (Door door in doors)
            door.GetComponent<Collider2D>().enabled = true;
    }

    void LoadChildRooms(){
        for (int i = 0; i < transform.childCount; i++){
            Room room = transform.GetChild(i).GetComponent<Room>();
            if (room != null)
                rooms.Add(room);
        }
    }

    void LoadChildDoors(){
        for (int i = 0; i < transform.childCount; i++)
        {
            Door door = transform.GetChild(i).GetComponent<Door>();
            if (door != null)
                doors.Add(door);
        }
    }


    void Link(){
        foreach(Room room in rooms)
            foreach (Room node in rooms)
                for (int i = 0; i < 4; i++)
					if (node.transform.position.x - room.transform.position.x + Room.XSize * Room.DirectionVectors[i].x < 0.005 &&
						node.transform.position.y - room.transform.position.y + Room.YSize * Room.DirectionVectors[i].y < 0.005)
                        room.nodes[i] = node;
            
    }
}
