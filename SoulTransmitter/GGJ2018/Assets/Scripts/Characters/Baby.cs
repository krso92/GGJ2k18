using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baby : Enemy {

	public float[] radiusOfSpawnMinMax = { 2f, 10f };

	public override void Init (Transform player)
	{
		base.Init (player);
		// stagod jos treba
	}

	public override void BehaviourUpdate() {
		
	}

	IEnumerator PerformTeleport() {
		var playerPos = playerRef.position;
		float angle = Random.Range (0, 360);
		float distance = Random.Range (radiusOfSpawnMinMax [0], radiusOfSpawnMinMax [1]);

		// if room.in_bounds()
		// room bounds da mi javi koliko je izaslo napolje da mogu da odradim safe flip
		// room moze i da javi da li je enemy ili neko drugi dosao tamo
		// 

		// must be in Room bounds, that must be in, collision check, local bounds
		// try couple of times
		// 
	}


}
