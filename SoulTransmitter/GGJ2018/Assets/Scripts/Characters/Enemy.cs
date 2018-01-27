using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	protected bool isAlive;
	protected Transform playerRef;

	void OnEnable(){
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isAlive) {
			BehaviourUpdate ();
		}
	}

	public virtual void Init(Transform player){
		this.playerRef = player;
		enabled = true;
	}

	public virtual void BehaviourUpdate(){
		throw new System.NotImplementedException ();
	}

	public virtual void Die(){
		isAlive = false;
		enabled = false;
	}

//	public void 
}
