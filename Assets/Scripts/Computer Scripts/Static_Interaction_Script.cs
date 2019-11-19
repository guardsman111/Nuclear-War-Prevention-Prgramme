using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Static_Interaction_Script : MonoBehaviour
{
    public GameObject Player;
    public GameObject uiText;
    public Transform interactPos;
    public GameObject screenController;

    public void OnTriggerEnter(Collider other)
    {
        uiText.SetActive(true);
        uiText.GetComponent<Text>().text = "PRESS F TO INTERACT";
    }

    public void OnTriggerExit(Collider other)
    {
        uiText.SetActive(false);
    }

    public void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Player.GetComponent<Player_Movement>().GetInteracting())
            {
                Player.GetComponent<Player_Movement>().SetInteracting(false);
                uiText.GetComponent<Text>().text = "PRESS F TO INTERACT";
                screenController.GetComponent<Screen_Controller_Script>().StopInteraction();
                screenController.SetActive(false);
            }
            else
            {
                Player.GetComponent<Player_Movement>().SetInteracting(true);
                Player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

                Player.transform.position = interactPos.transform.position;
                Player.transform.rotation = interactPos.transform.rotation;
                Camera.main.transform.localRotation = Quaternion.Euler(new Vector3(30.0f, 0, 0));

                uiText.GetComponent<Text>().text = "PRESS F TO STOP INTERACTING";

                screenController.SetActive(true);
                if (gameObject.tag == "Binary")
                {
                    screenController.GetComponent<Screen_Controller_Script>().SetBinary();
                }
                if (gameObject.tag == "Letter")
                {
                    screenController.GetComponent<Screen_Controller_Script>().SetLetter();
                }
                screenController.GetComponent<Screen_Controller_Script>().SetDigitsActive(0, true);
            }
        }
    }
}
