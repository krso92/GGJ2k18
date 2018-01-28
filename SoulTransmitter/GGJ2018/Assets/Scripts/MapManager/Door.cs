using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public Room a;
    public Room b;

    public bool exited = true;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (!exited) return;
        exited = false;

        Map.Instance.currentRoom.Exit();

        Room link = a == Map.Instance.currentRoom ? b : a;
  
        link.Transition();
        Map.Instance.currentRoom = link;

        TransferPlayers(coll.gameObject);
    }

    void TransferPlayers(GameObject user){
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