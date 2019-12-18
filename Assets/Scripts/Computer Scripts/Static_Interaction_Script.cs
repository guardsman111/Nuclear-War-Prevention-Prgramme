using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Static_Interaction_Script : MonoBehaviour
{
    public Player_Movement moveScript;
    public GameObject uiText;
    public GameObject screenController;
    public Transform letterPos;
    public Transform binaryPos;
    public Material keyInsertedColour;
    public Player_Constants_Script playerConstants;
    public Cancel_Button_Script cancelBut;
    public GameObject alarmLight;


    private string currentLook;
    private GameObject currentLookObj;

    public void FixedUpdate()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 5.0f))
        {
            if (hit.collider.tag == "Letter" || hit.collider.tag == "Binary")
            {
                uiText.SetActive(true);
                currentLook = hit.collider.tag;
                currentLookObj = hit.collider.gameObject;
            }
            if (hit.collider.tag == "KeySlot")
            {
                uiText.SetActive(true);
                currentLook = hit.collider.tag;
                currentLookObj = hit.collider.gameObject;
            }
            if (hit.collider.tag == "Button")
            {
                uiText.SetActive(true);
                currentLook = hit.collider.tag;
                currentLookObj = hit.collider.gameObject;
            }
            if (hit.collider.tag == "Alarm")
            {
                uiText.SetActive(true);
                currentLook = hit.collider.tag;
                currentLookObj = hit.collider.gameObject;
            }
        }
        else
        {
            uiText.SetActive(false);
            uiText.GetComponent<Text>().text = "PRESS F TO INTERACT";
        }


        if (Input.GetKeyUp(KeyCode.F))
        {
            if (moveScript.GetInteracting())
            {
                moveScript.SetInteracting(false);
                uiText.GetComponent<Text>().text = "PRESS F TO INTERACT";
                screenController.GetComponent<Screen_Controller_Script>().StopInteraction();
                screenController.SetActive(false);
            }
            else
            {


                if (currentLook == "Binary" || currentLook == "Letter")
                {
                    moveScript.SetInteracting(true);
                    GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                    Camera.main.transform.localRotation = Quaternion.Euler(new Vector3(30.0f, 0, 0));

                    uiText.GetComponent<Text>().text = "PRESS F TO STOP INTERACTING \n\n PRESS ENTER TO CHECK CODE";

                    screenController.SetActive(true);
                    if (currentLook == "Binary")
                    {
                        transform.position = binaryPos.position;
                        transform.rotation = binaryPos.rotation;
                        screenController.GetComponent<Screen_Controller_Script>().SetBinary();
                    }
                    if (currentLook == "Letter")
                    {
                        transform.position = letterPos.position;
                        transform.rotation = letterPos.rotation;
                        screenController.GetComponent<Screen_Controller_Script>().SetLetter();
                    }
                    screenController.GetComponent<Screen_Controller_Script>().SetDigitsActive(0, true);
                }


                if (currentLook == "KeySlot")
                {
                    if (playerConstants.CheckKeys(currentLookObj.GetComponent<Key_Slot_Script>().keyName))
                    {
                        currentLookObj.GetComponent<Key_Slot_Script>().keyInserted = true;
                        currentLookObj.GetComponent<MeshRenderer>().material = keyInsertedColour;
                        uiText.GetComponent<Text>().text = "KEY INSERTED!";
                    }
                    else
                    {
                        uiText.GetComponent<Text>().text = "COULD NOT INSERT KEY";
                        Debug.Log("Problem with key");
                    }
                }


                if (currentLook == "Button")
                {
                    cancelBut.CheckCancel();
                }


                if (currentLook == "Alarm")
                {
                    alarmLight.GetComponent<Light>().color = Color.white;
                    alarmLight.GetComponent<Alarm_Script>().AlarmOff();
                }
            }
        }
    }
}
