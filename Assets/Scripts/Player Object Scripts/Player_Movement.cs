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
    public Launch_Script screen;
    public Camera_Shake_Script shaker;

    private bool interacting = false;
    private AudioSource speaker;
    private bool locked = true;

    public bool launching = false;
    public float shakeMagnitude;

    [SerializeField]
    private Timer_Script timer;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
        cameraTransform = Camera.main.gameObject.transform;
        speaker = this.GetComponent<AudioSource>();
        Invoke("Unlock", 10.0f);
    }

    void FixedUpdate()
    {
        if (!locked)
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
                    timer.timer = 0;
                }

                if (Input.GetKey(KeyCode.K))
                {
                    screen.ChangeVideo("cancel");
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
    }

    public void SetInteracting(bool newV)
    {
        interacting = newV;
    }

    public bool GetInteracting()
    {
        return interacting;
    }

    public void Unlock()
    {
        locked = false;
        Destroy(GetComponentInChildren<Animator>());
    }
}
