using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    [SerializeField] ParticleSystem burstVFX;
    [SerializeField] Light pointLight;


    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth player = other.GetComponent<PlayerHealth>();
        if (player)
        {
            MakeBoom();
        }
    }

    void MakeBoom()
    {
        burstVFX.Play();
        GetComponent<AudioSource>().Play();
        Destroy(gameObject, 2);
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        StartCoroutine(DamageNear());
    }

    IEnumerator DamageNear()
    {
        pointLight.enabled = true;
        yield return new WaitForSeconds(0.15f);
        Collider[] nearObjects = Physics.OverlapSphere(transform.position, 5);
        for (int i = 0; i < nearObjects.Length; i++)
        {
            IDamagable obj = nearObjects[i].GetComponent<IDamagable>();
            if(obj != null)
            {
                obj.GetDamage(70);
            }
        }
        yield return new WaitForSeconds(0.15f);
        pointLight.enabled = false;
    }


}
