using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IDamagable
{
    public float hp = 100;
    [SerializeField] GameObject deathPanel;
    [SerializeField] Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        deathPanel.SetActive(false);
        healthBar.value = hp / 100;
    }

    public void RestoreHealth(float add)
    {
        hp += add;
        if (hp > 100) hp = 100;
        healthBar.value = hp / 100;
    }

    public void GetDamage(float damage)
    {
        hp -= damage;
        healthBar.value = hp / 100;
        GetComponent<AudioSource>().Play();

        if (hp <= 0.001f)
        {
            Death();
        }
    }

    void Death()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        FindObjectOfType<PlayerLook>().enabled = false;
        deathPanel.SetActive(true);
    }

    private void OnDestroy()
    {
        Time.timeScale = 1;
    }


}
