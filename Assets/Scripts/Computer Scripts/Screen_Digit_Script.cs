using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Screen_Digit_Script : MonoBehaviour
{
    public Text textBox;
    public int ID;

    public string[] binaryValues;
    public string[] letterValues;
    public string[] digitValues;
    private string currentValue;
    private int arrayValue;

    private bool interacting = false;

    private void Start()
    {
        currentValue = digitValues[0];
        arrayValue = 0;
    }

    private void Update()
    {
        if (interacting)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (arrayValue != digitValues.Length - 1)
                {
                    arrayValue += 1;
                    currentValue = digitValues[arrayValue];
                }
                else
                {
                    arrayValue = 0;
                    currentValue = digitValues[arrayValue];
                }
            }

            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (arrayValue > 0)
                {
                    arrayValue -= 1;
                    currentValue = digitValues[arrayValue];
                }
                else
                {
                    arrayValue = digitValues.Length - 1;
                    currentValue = digitValues[arrayValue];
                }
            }
            textBox.text = currentValue;
        }
    }

    public void SetInteracting(bool newV)
    {
        interacting = newV;
    }

    public bool GetInteracting()
    {
        return interacting;
    }

    public void SetArrayValue(int newV)
    {
        arrayValue = newV;
    }

    public int GetArrayValue()
    {
        return arrayValue;
    }

    public string GetValue()
    {
        return currentValue;
    }

    public void SetBinary()
    {
        digitValues = new string[10];
        for (int i = 0; i < digitValues.Length; i++)
        {
            digitValues[i] = binaryValues[i];
        }
    }

    public void SetLetter()
    {
        digitValues = new string[26];
        for(int i = 0; i < digitValues.Length; i++)
        {
            digitValues[i] = letterValues[i];
        }
    }

    public void ResetDigit()
    {
        currentValue = digitValues[arrayValue];
        textBox.text = currentValue;
    }
}
