using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baby : Enemy {

	public float[] radiusOfSpawnMinMax = { 2f, 10f };

	public ParticleSystem pSystem;

	public override void Init (Transform player)
	{
		base.Init (player);
	}

	public override void PerformAttackAction ()
	{
		var wha = Random.Range (0f, 1f);
		if (wha < .5f) {
			Shoot ();
		} else {
			StartCoroutine (PerformTeleport ());
		}
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
		yield return null;
	}

	public void Shoot(){
		// TODO kupimo ref na plehere odavde:
		// playerRef.position
		// pa emituj, a zasad
		throw new System.NotImplementedException("baby fires but no");
	}
}
