using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Script : MonoBehaviour
{
    public GameObject tinter;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FadeIn", 0.05f, 0.05f);
    }

    public void FadeIn()
    {
        if (tinter.GetComponent<MeshRenderer>().material.color.a > 0)
        {
            tinter.GetComponent<MeshRenderer>().material.color += new Color(0, 0, 0, -0.02f);
        }
        else
        {
            CancelInvoke("FadeIn");
        }
    }
}
