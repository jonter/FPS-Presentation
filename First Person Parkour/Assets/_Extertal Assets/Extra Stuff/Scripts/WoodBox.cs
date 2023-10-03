using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBox : MonoBehaviour, IDamagable
{
    float hp = 50;

    [SerializeField] GameObject[] prefabs;

    public void GetDamage(float damage)
    {
        hp -= damage;

        if (hp <= 0.001f)
        {
            Separate();
        }
        
    }

    void Separate()
    {
        GetComponent<BoxCollider>().enabled = false;
        Destroy(gameObject, 30);

        for (int i = 0; i < 20; i++)
        {
            transform.GetChild(i).GetComponent<MeshCollider>().enabled = true;
            Rigidbody rb = transform.GetChild(i).GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.velocity = Random.insideUnitSphere * 5;
        }

        int r = Random.Range(0, prefabs.Length);
        Vector3 spawnPos = transform.position + new Vector3(0, 0.5f, 0);
        Instantiate(prefabs[r], spawnPos, Quaternion.identity);

    }

}
