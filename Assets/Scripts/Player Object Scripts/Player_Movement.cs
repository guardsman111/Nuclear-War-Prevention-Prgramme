using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Rigidbody body;
    public float moveSpeed;
    public float rotateSpeed;
    public float minY;
    public float maxY;
    private float rotationY;
    private Transform cameraTransform;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
        cameraTransform = Camera.main.gameObject.transform;

    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (body.velocity.magnitude <= 2)
            {
                body.velocity += new Vector3(0, 0, moveSpeed);
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (body.velocity.magnitude <= 2)
            {
                body.velocity -= new Vector3(0, 0, moveSpeed);
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (body.velocity.magnitude <= 2)
            {
                body.velocity += new Vector3(moveSpeed, 0, 0f);
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (body.velocity.magnitude <= 2)
            {
                body.velocity -= new Vector3(moveSpeed, 0, 0.1f);
            }
        }

        transform.Rotate(0, Input.GetAxis("Mouse X") * rotateSpeed, 0);

        rotationY += Input.GetAxis("Mouse Y") * rotateSpeed;
        rotationY = Mathf.Clamp(rotationY, minY, maxY);

        cameraTransform.localEulerAngles = new Vector3(-rotationY, 0, 0);
    }
}
