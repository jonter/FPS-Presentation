using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject[] guns;

    int currentIndex = 0;

    bool pistolEnabled = false;
    bool automatEnabled = false;
    bool shotgunEnabled = false;

    // Start is called before the first frame update
    void Start()
    {
        guns[0].SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) SwitchWeapon(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SwitchWeapon(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SwitchWeapon(2);
        if (Input.GetKeyDown(KeyCode.Alpha4)) SwitchWeapon(3);
    }

    void SwitchWeapon(int newIndex)
    {
        if (newIndex == 1 && pistolEnabled == false) return;
        if (newIndex == 2 && automatEnabled == false) return;
        if (newIndex == 3 && shotgunEnabled == false) return;

        if (currentIndex == newIndex) return;
        Weapon w = guns[currentIndex].GetComponent<Weapon>();
        if (w.isAction == true) return;

        guns[currentIndex].SetActive(false);
        guns[newIndex].SetActive(true);
        currentIndex = newIndex;
    }

    public void AddAmmo(int index, int ammo)
    {
        guns[index].GetComponent<Weapon>().AddAmmo(ammo);
    }

    public void UnlockWeapon(int index)
    {
        if (index == 1) pistolEnabled = true;
        if (index == 2) automatEnabled = true;
        if (index == 3) shotgunEnabled = true;
        guns[index].GetComponent<Weapon>().AddAmmo(10);
        SwitchWeapon(index);
    }


}
