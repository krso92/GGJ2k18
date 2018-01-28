using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Text hp;
    public Text cassete;

    public PlayerController player;

    public void Update(){
        hp.text = player.playerHealth.ToString();
        cassete.text = "Oh no";
    }
}
