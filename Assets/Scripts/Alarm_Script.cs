using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm_Script : MonoBehaviour
{
    public Light lightObj;
    public bool alarmOn = true;
    private bool lightRise = true;

    private void FixedUpdate()
    {
        if (alarmOn)
        {
            if (lightRise && lightObj.intensity < 3)
            {
                lightObj.intensity += 0.1f;
            }
            else
            {
                lightRise = false;
            }

            if (!lightRise && lightObj.intensity > 0)
            {
                lightObj.intensity -= 0.1f;
            }
            else
            {
                lightRise = true;
            }

            if (GetComponent<AudioSource>().volume < 0.5)
            {
                GetComponent<AudioSource>().volume += 0.001f;
            }
        }
    }

    public void AlarmOff()
    {
        GetComponent<AudioSource>().Pause();
        alarmOn = false;
        lightObj.intensity = 1.6f;
        lightObj.range = 20f;
    }

    public void AlarmOn()
    {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().Play();
        }
        alarmOn = true;
        lightObj.color = Color.red;
        lightObj.range = 80f;
    }
}
