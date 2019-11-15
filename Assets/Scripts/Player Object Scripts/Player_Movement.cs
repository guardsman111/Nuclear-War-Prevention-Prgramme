using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Rigidbody body;
    public float moveSpeed;
    public float maxSpeed;
    public float rotateSpeed;
    public float minY;
    public float maxY;
    private float rotationY;
    private Transform cameraTransform;

    private bool interacting;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
        cameraTransform = Camera.main.gameObject.transform;
    }

    void FixedUpdate()
    {
        if (!interacting)
        {
            if (Input.GetKey(KeyCode.W))
            {
                if (Input.GetKey(KeyCode.D) & !Input.GetKey(KeyCode.A))
                {
                    if (body.velocity.magnitude <= maxSpeed)
                    {
                        body.velocity += (transform.right * moveSpeed) + (transform.forward * moveSpeed);
                    }
                }
                else if (Input.GetKey(KeyCode.A) & !Input.GetKey(KeyCode.D))
                {
                    if (body.velocity.magnitude <= maxSpeed)
                    {
                        body.velocity += (transform.right * -moveSpeed) + (transform.forward * moveSpeed);
                    }
                }
                else if (body.velocity.magnitude <= maxSpeed)
                {
                    body.velocity += transform.forward * moveSpeed;
                }
            }
            else if (Input.GetKey(KeyCode.S))
            {
                if (Input.GetKey(KeyCode.D) & !Input.GetKey(KeyCode.A))
                {
                    if (body.velocity.magnitude <= maxSpeed)
                    {
                        body.velocity += (transform.right * moveSpeed) + (transform.forward * -moveSpeed);
                    }
                }
                else if (Input.GetKey(KeyCode.A) & !Input.GetKey(KeyCode.D))
                {
                    if (body.velocity.magnitude <= maxSpeed)
                    {
                        body.velocity += (transform.right * -moveSpeed) + (transform.forward * -moveSpeed);
                    }
                }
                else if (body.velocity.magnitude <= maxSpeed)
                {
                    body.velocity += transform.forward * -moveSpeed;
                }
            }

            if (Input.GetKey(KeyCode.D))
            {
                if (body.velocity.magnitude <= maxSpeed)
                {
                    body.velocity += transform.right * moveSpeed;
                }
            }

            if (Input.GetKey(KeyCode.A))
            {
                if (body.velocity.magnitude <= maxSpeed)
                {
                    body.velocity += transform.right * -moveSpeed;
                }
            }

            transform.Rotate(0, Input.GetAxis("Mouse X") * rotateSpeed, 0);

            rotationY += Input.GetAxis("Mouse Y") * rotateSpeed;
            rotationY = Mathf.Clamp(rotationY, minY, maxY);

            cameraTransform.localEulerAngles = new Vector3(-rotationY, 0, 0);
        }
    }

    public void SetInteracting(bool newV)
    {
        interacting = newV;
    }

    public bool GetInteracting()
    {
        return interacting;
    }
}
