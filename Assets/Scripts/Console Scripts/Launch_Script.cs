using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Launch_Script : MonoBehaviour
{
    public VideoPlayer staticVideo;
    public VideoPlayer launchVideo;
    public VideoPlayer cancelVideo;
    public AudioSource launchAudio;
    public Start_Script blackness;
    public bool launched = false;

    private int video = 0;

    public void ChangeVideo(string name)
    {
        if (name == "launch")
        {
            staticVideo.Pause();
            launchVideo.Play();
            launchAudio.Play();
            video = 1;
        }
        if (name == "cancel")
        {
            staticVideo.Pause();
            cancelVideo.Play();
            video = 2;
        }
    }

    private void FixedUpdate()
    {
        if (video == 1)
        {
            if (!launchVideo.isPlaying)
            {
                blackness.InvokeRepeating("FadeOut", 2.0f, 0.05f);
            }
        }

        if (video == 2)
        {
            if (!cancelVideo.isPlaying)
            {
                blackness.InvokeRepeating("FadeOut", 1.0f, 0.05f);
            }
        }
    }
}
