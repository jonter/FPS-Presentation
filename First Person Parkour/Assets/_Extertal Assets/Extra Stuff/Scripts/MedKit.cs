using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKit : MonoBehaviour
{
    [SerializeField] float addHP = 50;

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth player = other.GetComponent<PlayerHealth>();
        if (player)
        {
            if (player.hp >= 100) return;
            player.RestoreHealth(addHP);
            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, 3.5f, 0);
    }
}
