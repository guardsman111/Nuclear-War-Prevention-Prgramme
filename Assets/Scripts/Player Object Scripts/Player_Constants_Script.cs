using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Constants_Script : MonoBehaviour
{
    private bool binaryKey = false;
    private bool letterKey = false;

    public void SetKey(string keyName, bool keyValue)
    {
        if (keyName == "binary")
        {
            binaryKey = keyValue;
        }
        if (keyName == "letter")
        {
            letterKey = keyValue;
        }
    }

    public bool CheckKeys(string keyName)
    {
        if (keyName == "binary")
        {
            return binaryKey;
        }
        if (keyName == "letter")
        {
            return letterKey;
        }
        else
        {
            return false;
        }
    }
}
