using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {

	public List<Enemy> enemies;

	public delegate void RoomEnter ();
	public delegate void RoomExit ();

	public event RoomEnter OnRoomEnter = delegate {};
	public event RoomExit OnRoomExit = delegate {};

	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Spawnuje sve redom
	void Spawn(){
		
	}
}
