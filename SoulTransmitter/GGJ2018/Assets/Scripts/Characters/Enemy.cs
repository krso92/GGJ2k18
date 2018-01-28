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

    public float health;

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
        gameObject.SetActive(false);
    }

    public void TakeDamage()
    {
        Debug.LogError("happening?");
        health -= 1f;
        if (health <= 0f)
        {
            Die();
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.layer == 9)
        {

        }
    }
}
