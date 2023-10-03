using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupWeapon : MonoBehaviour
{
    [SerializeField] int index = 1;

    [SerializeField] float rotateSpeed = 500;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHealth>())
        {
            Inventory inv = FindObjectOfType<Inventory>();
            inv.UnlockWeapon(index);
            Destroy(gameObject);
        }

    }


    void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        
    }
}
