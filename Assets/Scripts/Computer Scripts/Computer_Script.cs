using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer_Script : MonoBehaviour
{
    public string name;
    public string[] code;
    public int[] lastCodeTried = new int[4] { 0, 0, 0, 0 };

    public void SetLastCode(int dig1, int dig2, int dig3, int dig4)
    {
        lastCodeTried = new int[] { dig1, dig2, dig3, dig4 };
    }
}
