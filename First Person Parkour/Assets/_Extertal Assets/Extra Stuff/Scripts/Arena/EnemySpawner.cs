using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    

    public void SpawnNewEnemy()
    {
        
        Vector3 origin = transform.GetChild(1).position;
        Instantiate(enemyPrefab, origin, Quaternion.identity);

    }


   
}
