using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashLight : MonoBehaviour
{
    Animator anim;
    bool isOn = false;
    bool transition = false;

    AudioSource audio;
    [SerializeField] Light pointLight;
    [SerializeField] Light spotLight;

    float energy = 1;
    float chargeTime = 10;

    [SerializeField] Slider energyBar;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transition == true) return;

        if (Input.GetKeyDown(KeyCode.F))
        {
            isOn = !isOn;
            if (isOn == true) StartCoroutine(TurnOn());
            else StartCoroutine(TurnOff());
        }
        UseEnergy();
        energyBar.value = energy;
    }

    void UseEnergy()
    {
        if (isOn == true)
        {
            energy -= Time.deltaTime/chargeTime;
            if(energy <= 0)
            {
                isOn = false;
                StartCoroutine(TurnOff());
            }
        }
        else
        {
            energy += Time.deltaTime / chargeTime;
            if (energy > 1) energy = 1;
        }

    }


    IEnumerator TurnOn()
    {
        anim.SetTrigger("show");
        transition = true;
        yield return new WaitForSeconds(0.5f);
        pointLight.enabled = true;
        spotLight.enabled = true;
        audio.Play();
        transition = false;
    }

    IEnumerator TurnOff()
    {
        anim.SetTrigger("hide");
        transition = true;
        
        pointLight.enabled = false;
        spotLight.enabled = false;
        audio.Play();
        yield return new WaitForSeconds(0.5f);
        transition = false;
    }




}
