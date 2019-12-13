﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public Launch_Script screen;
    public Camera_Shake_Script shaker;

    private bool interacting;
    private AudioSource speaker;

    private bool launching = false;
    public float shakeMagnitude;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
        cameraTransform = Camera.main.gameObject.transform;
        speaker = this.GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (!interacting)
        {
            if (Input.GetKey(KeyCode.W))
            {
                if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
                {
                    if (body.velocity.magnitude <= maxSpeed)
                    {
                        body.velocity += (transform.right * moveSpeed) + (transform.forward * moveSpeed);
                    }
                }
                else if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
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
                if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
                {
                    if (body.velocity.magnitude <= maxSpeed)
                    {
                        body.velocity += (transform.right * moveSpeed) + (transform.forward * -moveSpeed);
                    }
                }
                else if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
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

            if (Input.GetKey(KeyCode.L))
            {
                screen.ChangeVideo("launch");
                shaker.LaunchShake();
                launching = true;
            }

            if (Input.GetKey(KeyCode.K))
            {
                screen.ChangeVideo("cancel");
            }

            if (Input.GetKey(KeyCode.P))
            {
                SceneManager.LoadScene(0);
            }

            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }

            transform.Rotate(0, Input.GetAxis("Mouse X") * rotateSpeed, 0);

            rotationY += Input.GetAxis("Mouse Y") * rotateSpeed;
            rotationY = Mathf.Clamp(rotationY, minY, maxY);

            if (!launching)
            {
                cameraTransform.localEulerAngles = new Vector3(-rotationY, 0.0f, 0.0f);
            }
            else
            {
                cameraTransform.localEulerAngles = new Vector3(-rotationY + (Random.Range(-shakeMagnitude, shakeMagnitude)), 0.0f + (Random.Range(-shakeMagnitude, shakeMagnitude)), 
                    0.0f + (Random.Range(-shakeMagnitude, shakeMagnitude)));
            }


            if (body.velocity.magnitude > 0.5f && !speaker.isPlaying)
            {
                speaker.Play();
            } 
            else if (body.velocity.magnitude < 0.5f && speaker.isPlaying)
            {
                speaker.Stop();
            }
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
