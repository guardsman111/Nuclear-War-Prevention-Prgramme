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

    public void ChangeVideo(string name)
    {
        if (name == "launch")
        {
            staticVideo.Pause();
            launchVideo.Play();
            launchAudio.Play();
            print(launchAudio.isPlaying);
        }
        if (name == "cancel")
        {
            staticVideo.Pause();
            cancelVideo.Play();
        }
    }
}
