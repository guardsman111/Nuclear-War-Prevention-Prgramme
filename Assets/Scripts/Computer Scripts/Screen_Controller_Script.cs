using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen_Controller_Script : MonoBehaviour
{
    public GameObject currentComputer;
    public GameObject binaryComputer;
    public GameObject letterComputer;

    public void SetBinary()
    {
        currentComputer = binaryComputer;
    }

    public void SetLetter()
    {
        currentComputer = letterComputer;
    }
}
