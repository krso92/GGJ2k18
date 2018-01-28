using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    public int attack;

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.layer == attack)
        {
            var enemy = GetComponentInParent<Enemy>();
            enemy.TakeDamage();
        }
    }

}
