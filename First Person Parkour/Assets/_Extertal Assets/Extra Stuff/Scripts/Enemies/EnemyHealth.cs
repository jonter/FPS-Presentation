using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamagable
{
    [SerializeField] float hp = 50;

    public void GetDamage(float damage)
    {
        hp -= damage;
        GetComponent<EnemyAI>().FollowPlayer();

        if(hp <= 0.0001f)
        {
            Death();
        }
    }

    protected virtual void Death()
    {
        int r = Random.Range(0, 2);
        if(r == 0)
            GetComponentInChildren<Animator>().SetTrigger("death");
        else
            GetComponentInChildren<Animator>().SetTrigger("death2");

        GetComponent<EnemyAI>().enabled = false;
        GetComponent<Collider>().enabled = false;
        Destroy(gameObject, 15);
    }
    
}
