using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public Room a;
    public Room b;

    public bool exited = true;
	
    void OnTriggerEnter2D(Collider2D collider){
        Debug.LogError(exited + "::");

        if (!exited) return;
        exited = false;

        Room link = a == Map.Instance.currentRoom ? b : a;
        Debug.LogError(link.name);
        link.Transition();
        Map.Instance.currentRoom = link;
        //Move players;
    }

    void OnTriggerExit2D(Collider2D collider){
        Debug.LogError(exited + "E");
        exited = true;
    }
}
