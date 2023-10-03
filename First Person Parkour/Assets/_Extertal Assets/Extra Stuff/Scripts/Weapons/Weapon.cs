using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected ParticleSystem fireVFX;
    [SerializeField] protected TMP_Text ammoText;
    protected Camera myCam;
    protected Animator anim;

    [SerializeField] protected ParticleSystem dustVFX;
    [SerializeField] protected ParticleSystem ketchupVFX;

    public bool isAction = false;

    protected int ammoAll = 100;
    protected int ammoMagazine = 8;

    protected int maxAmmo = 8;
    protected float damage = 10;
    protected float shootDelay = 0.2f;

    protected Aim aim;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        aim = FindObjectOfType<Aim>();
        myCam = Camera.main;
        UpdateText();
    }

    private void OnEnable()
    {
        anim = GetComponent<Animator>();
        UpdateText();
        anim.SetTrigger("show");
        StartCoroutine(BusyWeapon(0.5f));
    }

    public void AddAmmo(int add)
    {
        ammoAll += add;
        if (gameObject.activeInHierarchy == true) UpdateText();
    }

    protected IEnumerator BusyWeapon(float duration)
    {
        isAction = true;
        yield return new WaitForSeconds(duration);
        isAction = false;
    }

    protected virtual void UpdateText()
    {
        ammoText.text = ammoMagazine + "/" + ammoAll;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (isAction == true) return;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (ammoMagazine == maxAmmo) return;
            if (ammoAll == 0) return;
            StartCoroutine(BusyWeapon(1.2f));
            anim.SetTrigger("reload");
        }

    }


    public void Reload()
    {
        int ammoAdd = maxAmmo - ammoMagazine;
        if(ammoAll >= ammoAdd)
        {
            ammoMagazine = maxAmmo;
            ammoAll = ammoAll - ammoAdd;
        }
        else
        {
            ammoMagazine = ammoMagazine + ammoAll;
            ammoAll = 0;
        }
        UpdateText();
    }

    protected virtual void PlayEffect(RaycastHit hitInfo)
    {
        ParticleSystem effect = dustVFX;
        if (hitInfo.transform.GetComponent<EnemyHealth>()) effect = ketchupVFX;

        effect.transform.position = hitInfo.point;
        effect.transform.LookAt(hitInfo.point + hitInfo.normal);
        effect.Play();
    }


    protected virtual void Shoot()
    {
        if (ammoMagazine == 0) return;
        ammoMagazine--;
        GetComponent<AudioSource>().Play();
        UpdateText();
        StartCoroutine(BusyWeapon(shootDelay));
        anim.SetTrigger("shoot");
        fireVFX.Play();
        Vector3 origin = myCam.transform.position;
        Vector3 rand = Random.insideUnitSphere * aim.spread / 2;
        Vector3 dir = myCam.transform.forward + rand;
        float distance = 100;
        RaycastHit hitInfo;
        Physics.Raycast(origin, dir, out hitInfo, distance);

        if(hitInfo.transform)
        {
            IDamagable enemy = hitInfo.transform.GetComponent<IDamagable>();
            if (enemy != null)
            {
                enemy.GetDamage(damage);
            }
            PlayEffect(hitInfo);
            
        }
        aim.IncreaseSpread(0.1f);

    }
}
