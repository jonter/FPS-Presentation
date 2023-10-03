using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    protected override void Start()
    {
        ammoAll = 10;
        ammoMagazine = 0;
        maxAmmo = 0;
        damage = 12;
        shootDelay = 1;

        base.Start();
    }

    protected override void Update()
    {
        if (isAction == true) return;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }

    }

    protected override void UpdateText()
    {
        ammoText.text = "[" + ammoAll + "]";
    }

    protected override void Shoot()
    {
        if (ammoAll <= 0) return;
        ammoAll--;
        UpdateText();
        anim.SetTrigger("shoot");
        GetComponent<AudioSource>().Play();
        fireVFX.Play();
        StartCoroutine(BusyWeapon(shootDelay));

        for (int i = 0; i < 15; i++)
        {
            MakeRaycast();
        }

    }

    protected override void PlayEffect(RaycastHit hitInfo)
    {
        ParticleSystem effect = dustVFX;
        if (hitInfo.transform.GetComponent<EnemyHealth>()) effect = ketchupVFX;

        effect.transform.position = hitInfo.point;
        effect.transform.LookAt(hitInfo.point + hitInfo.normal);
        effect.Emit(5);
    }

    void MakeRaycast()
    {
        Vector3 origin = myCam.transform.position;
        Vector3 randVec = Random.insideUnitSphere * 0.2f;
        Vector3 dir = myCam.transform.forward + randVec;
        float distance = 25;
        RaycastHit hitInfo;
        Physics.Raycast(origin, dir, out hitInfo, distance);
        Debug.DrawRay(origin, dir * distance, Color.red, 2);

        if (hitInfo.transform)
        {
            IDamagable enemy = hitInfo.transform.GetComponent<IDamagable>();
            if (enemy != null)
            {
                enemy.GetDamage(damage);
            }
            PlayEffect(hitInfo);

        }

    }

}
