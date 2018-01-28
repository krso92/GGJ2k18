using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baby : Enemy
{
    public float[] radiusOfSpawnMinMax = { 2f, 10f };

    public ParticleSystem pSystem;

	public bool baba;

    private void OnEnable()
    {
        health = 20f;
		if (baba) {
			health *= 3f;
		}
    }

    public override void Init(Transform player)
    {
        base.Init(player);
    }

    public override void PerformAttackAction()
    {
        ThrowProjectile();
    }

    public void ThrowProjectile()
    {
        animator.SetTrigger("shoot");
    }

    public void Shoot()
    {
        Vector3 distance = transform.position - Map.Instance.Player1.transform.position;
        if (distance.x > 0)
        {
            animationHolderObj.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            animationHolderObj.rotation = Quaternion.Euler(0, 180, 0);
        }
        pSystem.transform.LookAt(Map.Instance.Player1.transform.position);
        pSystem.Emit(1);
    }
}
