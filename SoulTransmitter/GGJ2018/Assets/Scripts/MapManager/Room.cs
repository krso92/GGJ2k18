using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {
    public const float XSize = 13;
    public const float YSize = 9;

    public static float transitionSpeed = 10;

	public List<Enemy> enemies;
    public GameObject player;
    //public List<GameObject> obstacles;

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

    void Transition(Room target){
        StartCoroutine(TransitionIE(target));
    }

    public IEnumerator TransitionIE(Room room)
    {
        //Time scale za pauzu, mozda nam zajebe nesto pa cemo menjat
        Time.timeScale = 0;

        while (Vector3.Distance(Camera.main.transform.position, room.transform.position) < 0.5f)
        {
            //Pomeriti playera takodje

            Camera.main.transform.position = Vector3.Lerp(room.transform.position, Camera.main.transform.position, 0.5f);
            yield return new WaitForSecondsRealtime(1 / transitionSpeed);
        }

        Time.timeScale = 1;
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

    void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Door")
            Debug.Log("Door hit");
    }
}
