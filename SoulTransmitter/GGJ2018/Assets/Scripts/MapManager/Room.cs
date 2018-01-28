using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public static float transitionSpeed = 50;

    public List<Enemy> enemies;

    public delegate void RoomEnter(Room room);
    public delegate void RoomExit(Room room);

    public event RoomEnter OnRoomEnter = delegate { };
    public event RoomExit OnRoomExit = delegate { };

    // Use this for initialization
    void Start()
    {
        OnRoomEnter += InitEnemies;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Spawnuje sve redom
    void Spawn()
    {

    }

    public void Transition()
    {
        StartCoroutine(TransitionIE(this));
    }

    public void Exit()
    {
        OnRoomExit(this);
    }

    public IEnumerator TransitionIE(Room room)
    {
        Vector3 newpos = Camera.main.transform.position;

        while (Vector3.Distance(room.transform.position, newpos) > 0.1f)
        {
            newpos = Vector3.Lerp(room.transform.position, Camera.main.transform.position, 0.5f);
            newpos.z = -10;
            Camera.main.transform.position = newpos;
            yield return new WaitForSecondsRealtime(1 / transitionSpeed);
            newpos.z = room.transform.position.z;
        }

        OnRoomEnter(this);
    }

    public Enemy CheckNotSafe(Vector3 pos)
    {
        Vector3 correctPos = pos;

        foreach (Enemy e in enemies)
        {
            correctPos.z = e.transform.position.z;
            if (e.GetComponent<Collider2D>().bounds.Contains(pos))
                return e;
        }

        return null;
    }

    public Vector3 GetSafe(Vector3 pos, GameObject player)
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

    void InitEnemies(Room room)
    {
        foreach (var enemy in room.enemies)
        {
            enemy.Init(Map.Instance.Player1.transform);
        }
    }
}