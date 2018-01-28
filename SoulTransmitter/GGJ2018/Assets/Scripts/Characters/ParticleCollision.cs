using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{





    private void OnParticleCollision(GameObject other)
    {
        Debug.LogError("UDARA U ENEMY");
        if (other.gameObject.layer == 10)
        {
            //Skidaj health
        }
    }

}
