﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Screen_Controller_Script : MonoBehaviour
{
    private GameObject currentComputer;
    public GameObject binaryComputer;
    public GameObject letterComputer;
    public Player_Constants_Script playerConstants;
    public GameObject uiText;

    public AudioSource keySide;
    public AudioSource keyUp;
    public AudioSource keyDown;

    private int arrayValue = 0;

    public Screen_Digit_Script[] screenDigits;

    private bool updatedComputerType = false;

    private void Update()
    {
        if (updatedComputerType == false)
        {
            foreach (Screen_Digit_Script i in screenDigits)
            {
                i.SetArrayValue(currentComputer.GetComponent<Computer_Script>().lastCodeTried[i.ID]);
                i.ResetDigit();
            }
            updatedComputerType = true;
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (arrayValue != 0)
            {
                SetDigitsActive(arrayValue, false);
                arrayValue -= 1;
                SetDigitsActive(arrayValue, true);
            }
            else
            {
                SetDigitsActive(arrayValue, false);
                arrayValue = screenDigits.Length - 1;
                SetDigitsActive(arrayValue, true);
            }
            keySide.Play();
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (arrayValue != screenDigits.Length - 1)
            {
                SetDigitsActive(arrayValue, false);
                arrayValue += 1;
                SetDigitsActive(arrayValue, true);
            }
            else
            {
                SetDigitsActive(arrayValue, false);
                arrayValue = 0;
                SetDigitsActive(arrayValue, true);
            }
            keySide.Play();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (screenDigits[0].GetValue() == currentComputer.GetComponent<Computer_Script>().code[0] &&
                screenDigits[1].GetValue() == currentComputer.GetComponent<Computer_Script>().code[1] &&
                screenDigits[2].GetValue() == currentComputer.GetComponent<Computer_Script>().code[2] &&
                screenDigits[3].GetValue() == currentComputer.GetComponent<Computer_Script>().code[3])
            {
                if (currentComputer.GetComponent<Computer_Script>().name == "binary")
                {
                    playerConstants.SetKey("binary", true);
                    uiText.GetComponent<Text>().text = "GOT KEY!";
                    Debug.Log("Get Key");
                }
                if (currentComputer.GetComponent<Computer_Script>().name == "letter")
                {
                    playerConstants.SetKey("letter", true);
                    uiText.GetComponent<Text>().text = "GOT KEY!";
                    Debug.Log("Get Key");
                }
            }
            else
            {
                uiText.GetComponent<Text>().text = "INCORRECT CODE";
                Invoke("ResetText", 0.5f);
            }
        }
    }

    public void SetBinary()
    {
        currentComputer = binaryComputer;
        foreach (Screen_Digit_Script i in screenDigits)
        {
            i.SetBinary();
        }
    }

    public void SetLetter()
    {
        currentComputer = letterComputer;
        foreach (Screen_Digit_Script i in screenDigits)
        {
            i.SetLetter();
        }
    }

    public void SetDigitsActive(int ID, bool newV)
    {
        screenDigits[ID].SetInteracting(newV);
    }

    public void StopInteraction()
    {
        updatedComputerType = false;
        screenDigits[arrayValue].SetInteracting(false);
        currentComputer.GetComponent<Computer_Script>().SetLastCode(screenDigits[0].GetArrayValue(), screenDigits[1].GetArrayValue(), screenDigits[2].GetArrayValue(), screenDigits[3].GetArrayValue());
    }

    public void ResetText()
    {
        uiText.GetComponent<Text>().text = "PRESS F TO STOP INTERACTING";
    }

    public void PlayKeyUp()
    {
        keyUp.Play();
    }

    public void PlayKeyDown()
    {
        keyDown.Play();
    }
}
