using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    [SerializeField] float speed = 8;
    [SerializeField] float flySpeed = 0.5f;

    [SerializeField] float gravity = 10;
    [SerializeField] float jumpSpeed = 8;

    float speedY = 0;

    public Vector3 velocity;
    public bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveOnPlane();
        MoveVertical();
    }

    void MoveOnPlane()
    {
        float inputZ = Input.GetAxis("Vertical") * speed;
        float inputX = Input.GetAxis("Horizontal") * speed;

        if(isGrounded == true)
        {
            velocity = transform.forward * inputZ + transform.right * inputX;
        }
        else
        {
            Vector3 dir = transform.forward * inputZ + transform.right * inputX;
            velocity += dir * Time.deltaTime * flySpeed;
        }

        if (velocity.magnitude > speed) velocity = velocity.normalized * speed;
        controller.Move(velocity * Time.deltaTime);
    }

    void MoveVertical()
    {
        speedY = speedY - gravity * Time.deltaTime;
        LayerMask ground = LayerMask.GetMask("Ground");
        Vector3 center = transform.position + new Vector3(0, -1, 0);
        isGrounded = Physics.CheckSphere(center, 0.2f, ground);
        CheckSurface();
        CheckHead();
        if (isGrounded == true && speedY < 0)
        {
            speedY = -2;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                speedY = jumpSpeed;
            }
        }

        Vector3 velY = new Vector3(0, speedY, 0);
        controller.Move(velY * Time.deltaTime);
    }

    void CheckHead()
    {
        LayerMask ground = LayerMask.GetMask("Ground");
        Vector3 pos = transform.position + new Vector3(0, 1, 0);
        bool isHead = Physics.CheckSphere(pos, 0.2f, ground);
        if (isHead == true && speedY > 0) speedY = -2;

    }

    void CheckSurface()
    {
        Vector3 origin = transform.position;
        Vector3 dir = -transform.up;
        float distance = 1.5f;
        LayerMask groundLayer = LayerMask.GetMask("Ground");
        RaycastHit hitInfo;
        Physics.Raycast(origin, dir, out hitInfo, distance, groundLayer);
        if (hitInfo.transform)
        {
            float angle = Vector3.Angle(transform.up, hitInfo.normal);
            if(angle > 50)
            {
                isGrounded = false;
            }
        }
    }


}
