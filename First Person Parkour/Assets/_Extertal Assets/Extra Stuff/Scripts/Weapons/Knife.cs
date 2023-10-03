using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : Weapon
{
    protected override void UpdateText()
    {
        ammoText.text = "---";
    }

    protected override void Update()
    {
        if (isAction == true) return;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(BusyWeapon(0.42f));
            anim.SetTrigger("attack");
        }

    }

    public void Attack()
    {
        Vector3 origin = myCam.transform.position;
        Vector3 dir = myCam.transform.forward;
        float distance = 1.5f;
        RaycastHit hitInfo;
        Physics.Raycast(origin, dir, out hitInfo, distance);
        if (hitInfo.transform)
        {
            IDamagable enemy = hitInfo.transform.GetComponent<IDamagable>();
            if (enemy != null)
            {
                enemy.GetDamage(20);
            }
        }

    }

}
