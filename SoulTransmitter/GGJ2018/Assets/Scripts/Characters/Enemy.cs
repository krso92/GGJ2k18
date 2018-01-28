using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    protected bool isAlive;
    protected Transform playerRef;

    public float waitTimeMin = 3f;
    public float waitTimeMax = 8f;

    public Animator animator;

    public Transform animationHolderObj;

    public virtual void Init(Transform player)
    {
        this.playerRef = player;
        enabled = true;
        isAlive = true;
        StartCoroutine(BehaviourDeterminator());
    }

    public virtual void PerformAttackAction()
    {
        throw new System.NotImplementedException();
    }

    IEnumerator BehaviourDeterminator()
    {
        while (isAlive)
        {
            yield return new WaitForSeconds(Random.Range(waitTimeMin, waitTimeMax));
            PerformAttackAction();
        }
    }

    public virtual void Die()
    {
        isAlive = false;
        enabled = false;
    }
}
