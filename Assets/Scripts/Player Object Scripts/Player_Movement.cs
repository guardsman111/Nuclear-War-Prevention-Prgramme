using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Rigidbody body;
    public float moveSpeed;
    public float rotateSpeed;
    public int cameraLock;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
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

        Vector3 lookTarget = new Vector3(0, 0, 0);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            lookTarget = hit.point;
        }

        Vector3 lookDelta = (hit.point - transform.position);
        Quaternion targetRot = Quaternion.LookRotation(lookDelta);
        float rotSpeed = rotateSpeed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, rotSpeed);
    }
}
