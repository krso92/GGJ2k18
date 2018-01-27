using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Map : MonoBehaviour {
    public const string ROOM_NAME = "room_";

    public TextAsset mapFile;

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

    Room Spawn(int xStart, int yStart){
        string fullMap = mapFile.text;

        string[] lines = fullMap.Split('\n');

		Room spawn = null;

        for (int x = 0; x < lines.Length; x++)
            for (int y = 0; y < lines.Length; y++){
                GameObject prefab = Resources.Load<GameObject>(ROOM_NAME + lines[y][x]);

                GameObject roomGO = GameObject.Instantiate(prefab, new Vector3(-x * Room.XSize, y * Room.YSize), Quaternion.identity);
                Room room = roomGO.GetComponent<Room>();

                if(!room){
                    Debug.LogError("Neko bre zaboravio skriptu room stavit na sobu");
                    throw new Exception("Invalid Prefab");
                }

                if (xStart == x && yStart == y)
                    spawn = room;

                rooms.Add(room);
            }

        return spawn;
    }


}
