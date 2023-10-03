using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Automat : Weapon
{

    protected override void Start()
    {
        maxAmmo = 30;
        ammoMagazine = maxAmmo;
        shootDelay = 0.1f;
        damage = 15;
        ammoAll = 50;

        base.Start();
    }

    protected override void Update()
    {
        if (isAction == true) return;

        if (Input.GetKey(KeyCode.Mouse0))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (ammoAll == 0) return;
            if (ammoMagazine == maxAmmo) return;
            anim.SetTrigger("reload");
            StartCoroutine(BusyWeapon(2));
        }
        
    }

}
