using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key_Slot_Script : MonoBehaviour
{
    public string keyName;

    public bool keyInserted = false;

    public bool CheckKeysInserted()
    {
        return keyInserted;
    }
}
