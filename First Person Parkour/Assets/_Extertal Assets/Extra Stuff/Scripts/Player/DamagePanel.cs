using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamagePanel : MonoBehaviour
{
    PlayerHealth player;
    Image img;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        img = GetComponent<Image>();
        player = FindObjectOfType<PlayerHealth>();
        img.color = new Color(1, 1, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float percentage = player.hp / 100;
        float alpha = 1 - percentage;
        img.color = new Color(1, 1, 1, alpha);

        if(percentage > 0.4f)
        {
            audio.Stop();
        }
        else if(audio.isPlaying == false) 
        {
            audio.Play();
        }
        
    }
}
