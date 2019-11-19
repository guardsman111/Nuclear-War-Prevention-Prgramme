using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key_Slot_Script : MonoBehaviour
{
    public Material keyInsertedColour;
    public Player_Constants_Script playerConstants;
    public string keyName;
    public GameObject uiText;

    private bool keyInserted = false;

    public void OnTriggerEnter(Collider other)
    {
        uiText.SetActive(true);
        uiText.GetComponent<Text>().text = "PRESS F TO INSERT KEY";
    }

    public void OnTriggerExit(Collider other)
    {
        uiText.SetActive(false);
    }

    public void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (playerConstants.CheckKeys(keyName))
            {
                keyInserted = true;
                gameObject.GetComponent<MeshRenderer>().material = keyInsertedColour;
                uiText.GetComponent<Text>().text = "KEY INSERTED!";
            }
            else
            {
                uiText.GetComponent<Text>().text = "COULD NOT INSERT KEY";
                Debug.Log("Problem with key");
            }
        }
    }

    public bool CheckKeysInserted()
    {
        return keyInserted;
    }
}
