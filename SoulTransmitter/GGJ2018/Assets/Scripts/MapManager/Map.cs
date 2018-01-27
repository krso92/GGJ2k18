using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

	public Room startRoom;
	public Room exitRoom;

	private List<Room> rooms;

	public delegate void InitFinished();

	public event InitFinished OnInitFinished;

	// Use this for initialization
	void Start () {
		startRoom.OnRoomEnter.Invoke ();
	}
	
	// Update is called once per frame
	void Update () {
		// mozda nesto
	}


	// 

	void Init(){
		
	}

}
