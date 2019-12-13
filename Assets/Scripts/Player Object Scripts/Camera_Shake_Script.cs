using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class Camera_Shake_Script : MonoBehaviour
{
    private Stopwatch count;
    public Transform player;
    public void LaunchShake()
    {
        count = new Stopwatch();
        count.Start();
    }

    public void FixedUpdate()
    {
        if (count != null)
        {
            if (count.ElapsedMilliseconds <= 1000.0f)
            {
                player.GetComponent<Player_Movement>().shakeMagnitude = 0.1f;
            }
            else if (count.ElapsedMilliseconds > 1000.0f && count.ElapsedMilliseconds <= 3000.0f)
            {
                player.GetComponent<Player_Movement>().shakeMagnitude = 0.3f;
            }
            else if (count.ElapsedMilliseconds > 3000.0f && count.ElapsedMilliseconds <= 6000.0f)
            {
                player.GetComponent<Player_Movement>().shakeMagnitude = 0.5f;
            }
            else if (count.ElapsedMilliseconds > 6000.0f && count.ElapsedMilliseconds <= 9000.0f)
            {
                player.GetComponent<Player_Movement>().shakeMagnitude = 0.7f;
            }
            else if (count.ElapsedMilliseconds > 9000.0f && count.ElapsedMilliseconds <= 11000.0f)
            {
                player.GetComponent<Player_Movement>().shakeMagnitude = 2.0f;
            }
            else if (count.ElapsedMilliseconds > 11000.0f && count.ElapsedMilliseconds <= 12000.0f)
            {
                player.GetComponent<Player_Movement>().shakeMagnitude = 1.0f;
            }
            else if (count.ElapsedMilliseconds > 12000 && player.GetComponent<Player_Movement>().shakeMagnitude > 0)
            {
                player.GetComponent<Player_Movement>().shakeMagnitude -= 0.002f;
            }
            else if (count.ElapsedMilliseconds > 12000 && player.GetComponent<Player_Movement>().shakeMagnitude <= 0)
            {
                Destroy(this);
            }
        }
    }
}
