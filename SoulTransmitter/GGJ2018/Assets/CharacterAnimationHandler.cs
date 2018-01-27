using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationHandler : MonoBehaviour {

	public PlayerController ctrl;
	public Animator animator;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (ctrl);
		if (ctrl.Move != Vector2.zero) {
			if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("walk")) {
				animator.SetTrigger ("walk");
			}
		}
		else {
			if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("idle")) {
				animator.SetTrigger ("idle");
			}
		}
	}

//	public void Update
}
