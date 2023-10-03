using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    float minSpread = 0;
    public float spread = 0;

    float mult = 300;
    RectTransform myrect;

    float decreaseSpeed = 7;
    PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        myrect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        SpreadOnMove();
        spread = Mathf.SmoothStep(spread, minSpread, decreaseSpeed * Time.deltaTime);

        float size = spread * mult;
        myrect.sizeDelta = new Vector2(size, size);

    }

    void SpreadOnMove()
    {
        minSpread = 0;
        if (player.isGrounded == false) minSpread = 0.1f;
        if (player.velocity.magnitude > 1) minSpread = 0.1f;
        if (player.isGrounded == false && player.velocity.magnitude > 1) minSpread = 0.2f;

    }


    public void IncreaseSpread(float add)
    {
        spread += add;
    }

}
