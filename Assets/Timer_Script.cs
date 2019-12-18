using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Timer_Script : MonoBehaviour
{
    public TextMeshPro text;
    public double timer;
    private string timeString;
    public Launch_Script launcher;
    public GameObject lightObj;
    public Player_Movement player;
    public Camera_Shake_Script shaker;

    // Start is called before the first frame update
    void Start()
    {
        timer = 300;
    }

    // Update is called once per frame
    void Update()
    {
        TimeSpan seconds = TimeSpan.FromSeconds(timer);
        timeString = string.Format("{0:00}:{1:00}:{2:00}", seconds.Hours, seconds.Minutes, seconds.Seconds);
        text.text = timeString;

        if (timer < 0)
        {
            launcher.ChangeVideo("launch");
            lightObj.GetComponent<Alarm_Script>().AlarmOn();
            player.launching = true;
            shaker.LaunchShake();
            Destroy(this);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
