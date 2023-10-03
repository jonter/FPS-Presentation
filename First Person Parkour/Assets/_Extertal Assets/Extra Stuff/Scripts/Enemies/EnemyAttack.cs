using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    
    public void MakeHit()
    {
        PlayerHealth player = FindObjectOfType<PlayerHealth>();
        player.GetDamage(25);
    }

}
