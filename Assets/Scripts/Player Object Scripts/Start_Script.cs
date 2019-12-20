using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Script : MonoBehaviour
{
    public GameObject tinter;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FadeIn", 0.1f, 0.1f);
    }

    public void FadeIn()
    {
        if (tinter.GetComponent<MeshRenderer>().material.color.a > 0)
        {
            tinter.GetComponent<MeshRenderer>().material.color += new Color(0, 0, 0, -0.01f);
        }
        else
        {
            CancelInvoke("FadeIn");
        }
    }

    public void FadeOut()
    {
        if (tinter.GetComponent<MeshRenderer>().material.color.a < 1)
        {
            tinter.GetComponent<MeshRenderer>().material.color -= new Color(0, 0, 0, -0.005f);
        }
        else
        {
            CancelInvoke("FadeIn");
            SceneManager.LoadScene(0);
        }
    }
}
