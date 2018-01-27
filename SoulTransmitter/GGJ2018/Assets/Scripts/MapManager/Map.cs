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
}
