using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.UI;

public class PhoneUnlockManager : MonoBehaviour
{
    public TMP_InputField inputField;
    public GameObject phoneNotesPanel;
    public GameObject lockedPanel;
    public TMP_Text passcodeStatusText;

    private string correctCode =  "0512";

    // Start is called before the first frame update
    void Start()
    {
        inputField.characterLimit = 4;
        inputField.text = "";
    }
    public void AddDigit(string digit)
    {
        if(inputField.text.Length< 4)
        {
            inputField.text += digit;
        }
    }
    public void Backspace()
    {
        if(inputField.text.Length > 0)
        {
            inputField.text = inputField.text.Substring(0, inputField.text.Length - 1);
        }
    }
    public void SubmitCode()
    {
        if(inputField.text == correctCode)
        {
            lockedPanel.SetActive(false);
            phoneNotesPanel.SetActive(true);
             
        }
        else
        {
            inputField.text = "";

            if(passcodeStatusText != null)
            {
                passcodeStatusText.text = "Incorrect Passcode";
                Invoke("restPasscodeText", 2f);
            }
        }
    }

    private void ResetPasscodeText()
    {
        if (passcodeStatusText != null)
        {
            passcodeStatusText.text = "Enter Passcode";
        }
           
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
