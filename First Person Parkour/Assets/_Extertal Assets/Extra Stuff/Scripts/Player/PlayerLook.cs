using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    float rotationX = 0;
    [SerializeField] Transform player;

    [SerializeField] float mouseSensivity = 2;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity;

        rotationX = rotationX - mouseY;
        rotationX = Mathf.Clamp(rotationX, -80, 80);

        transform.localRotation = Quaternion.Euler(rotationX, 0 , 0);

        player.Rotate(0, mouseX, 0);
    }
}
