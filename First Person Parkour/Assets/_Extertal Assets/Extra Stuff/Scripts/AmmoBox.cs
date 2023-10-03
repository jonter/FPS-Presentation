using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    // 1- �������� 2- ������� 3- ��������
    [SerializeField] int index = 1;
    [SerializeField] int ammo = 50;

    [SerializeField] float rotationSpeed = 300;

    private void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHealth>())
        {
            Inventory inv = FindObjectOfType<Inventory>();
            inv.AddAmmo(index, ammo);
            Destroy(gameObject);
        }
        
    }

}
