using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HintText : MonoBehaviour
{
    TMP_Text myText;
    PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponent<TMP_Text>();
        player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position);
    }

    public void SetText(string s)
    {
        myText.text = s;
    }

}
