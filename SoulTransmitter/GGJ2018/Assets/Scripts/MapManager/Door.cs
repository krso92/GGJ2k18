using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public Room a;
    public Room b;

    public GameObject aEntrance;
    public GameObject bEntrance;

    public bool exited = true;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.layer != LayerMask.NameToLayer("Player"))
            return;

        if (!exited) return;
        exited = false;

        Map.Instance.currentRoom.Exit();

        Room link = a == Map.Instance.currentRoom ? b : a;
        GameObject entrance = a == Map.Instance.currentRoom ? bEntrance : aEntrance;

        link.Transition();
        Map.Instance.currentRoom = link;
        Debug.LogWarning(entrance);
        if (!entrance)
            TransferPlayers(coll.gameObject);
        else
        {
            Vector3 pos = entrance.transform.position;
            pos.z = Map.Instance.Player1.transform.position.z;
            Map.Instance.Player1.transform.position = pos;
        }
    }

    void TransferPlayers(GameObject user)
    {
        Vector3 look = (transform.position - user.transform.position).normalized;
        look.z = 0;
        look = look * 10;

        Vector3 destination = user.transform.position + look;
        //Vector3 destRadio = user.transform.position + look * 5;


        Map.Instance.Player1.transform.position = destination;
        //Map.Instance.Player2.transform.position = destRadio;
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        Debug.LogError(exited + "E");
        exited = true;
    }
}