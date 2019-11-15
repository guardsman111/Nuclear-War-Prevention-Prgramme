using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen_Controller_Script : MonoBehaviour
{
    private GameObject currentComputer;
    public GameObject binaryComputer;
    public GameObject letterComputer;

    private int arrayValue = 0;

    public Screen_Digit_Script[] screenDigits;

    private void Update()
    {
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
        }
    }

    public void SetBinary()
    {
        currentComputer = binaryComputer;
    }

    public void SetLetter()
    {
        currentComputer = letterComputer;
    }

    public void SetDigitsActive(int ID, bool newV)
    {
        screenDigits[ID].SetInteracting(newV);
    }

    public void StopInteraction()
    {
        screenDigits[arrayValue].SetInteracting(false);
    }
}
