using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{


    public const float XSize = 13;
    public const float YSize = 9;

    public static float transitionSpeed = 50;

    public enum Directions { Up, Left, Down, Right };
    public static Vector3[] DirectionVectors = { new Vector3(0, 1), new Vector3(1, 0), new Vector3(0, -1), new Vector3(-1, 0) };
    public Room[] nodes = new Room[4];

	public List<Enemy> enemies;
    public GameObject player;

    public Door[] doors;

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

    public void Transition(){
        StartCoroutine(TransitionIE(this));
    }



    public IEnumerator TransitionIE(Room room)
    {
        OnRoomExit();
        Vector3 newpos = Camera.main.transform.position;
        Debug.Log(Vector3.Distance(Camera.main.transform.position, room.transform.position));
        while (Vector3.Distance(room.transform.position, newpos) > 0.5f)
        {
            
            newpos = Vector3.Lerp(room.transform.position, Camera.main.transform.position, 0.5f);
            newpos.z = -10;
            Camera.main.transform.position = newpos;
            yield return new WaitForSecondsRealtime(1 / transitionSpeed);
            newpos.z = room.transform.position.z;
            Debug.Log(Vector3.Distance(Camera.main.transform.position, room.transform.position));
        }
        Debug.Log("TRANS");
        Map.Instance.EnableDoors();

        OnRoomEnter();
    }

    public Enemy CheckNotSafe(Vector3 pos){
        Vector3 correctPos = pos;

        foreach(Enemy e in enemies){
            correctPos.z = e.transform.position.z;
            if (e.GetComponent<Collider2D>().bounds.Contains(pos))
                return e;
        }

        return null;
    }

    public Vector3 GetSafe(Vector3 pos)
    {
        Vector3 offset = pos - player.transform.position;
        Vector3 rotated;

        for (int i = 0; i < 8; i++)
        {
            rotated = (Quaternion.Euler(0, 45f * i, 0) * offset) + player.transform.position;
            if (!CheckNotSafe(rotated))
                return rotated;
        }

        return Vector3.zero;
    }
}
