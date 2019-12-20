using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Menu_Script : MonoBehaviour
{
    public Image blackness;
    public bool start = false;

    public void Play()
    {
        start = true;
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void FixedUpdate()
    {
        if (start)
        {
            if (blackness.color.a < 1)
            {
                print(blackness.color.a);
                blackness.color -= new Color(0, 0, 0, -0.02f);
            }
            if (blackness.color.a >= 1)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
