using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cancel_Button_Script : MonoBehaviour
{
    public Key_Slot_Script key1;
    public Key_Slot_Script key2;
    public GameObject uiText;
    public Launch_Script screen;

    public void OnTriggerEnter(Collider other)
    {
        uiText.SetActive(true);
        uiText.GetComponent<Text>().text = "PRESS F TO PRESS BUTTON";
    }

    public void OnTriggerExit(Collider other)
    {
        uiText.SetActive(false);
    }

    public void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (key1.CheckKeysInserted() && key2.CheckKeysInserted())
            {
                uiText.GetComponent<Text>().text = "LAUNCH CANCELLED!";
                screen.ChangeVideo("cancel");
                Debug.Log("You stopped the launch!");
            }
            else
            {
                uiText.GetComponent<Text>().text = "UNABLE TO CANCEL LAUNCH";
                Debug.Log("Problem with Keys");
            }
        }
    }
}
