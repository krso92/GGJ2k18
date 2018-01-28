using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    public int layer;
    public int attack;

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.layer == layer)
        {
            Debug.LogError("Uslooo");
            var enemy = other.GetComponentInParent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage();
            }
            var player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.DamageMeBaby(attack);
            }

        }
    }

}
