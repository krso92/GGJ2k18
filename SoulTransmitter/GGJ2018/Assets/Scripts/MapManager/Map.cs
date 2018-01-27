using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Map : MonoBehaviour {
    [HideInInspector]
	public Room startRoom;
    [HideInInspector]
	public Room exitRoom;
    [HideInInspector]
    public Room currentRoom;

	private List<Room> rooms;

	public delegate void InitFinished();

	public event InitFinished OnInitFinished;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		// mozda nesto
	}


	// 

	void Init(){
		
	}

    void Link(){
        foreach(Room room in rooms)
            foreach (Room node in rooms)
                for (int i = 0; i < 4; i++)
                    if (node.transform.position.x - room.x + Room.XSize * Room.DirectionVectors[i].x < 0.005 &&
                        node.transform.position.y - room.y + Room.YSize * Room.DirectionVectors[i].y < 0.005)
                        room.nodes[i] = node;
            
    }
}
