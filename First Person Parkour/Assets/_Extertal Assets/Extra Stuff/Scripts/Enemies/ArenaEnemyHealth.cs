using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaEnemyHealth : EnemyHealth
{
    [SerializeField] GameObject[] pickupPrefabs;

    protected override void Death()
    {
        base.Death();
        int rand = Random.Range(0, pickupPrefabs.Length);
        Instantiate(pickupPrefabs[rand], transform.position, Quaternion.identity);
    }

}
