using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserData : MonoBehaviour
{

    public InputField userNameInput;
    public static string userName;
    public InputField gmailPasswordInput;
    public static string gmailPassword;
    public InputField birthdayInput;
    public static string birthday;
    public InputField ssnInput;
    public static string ssn;
    public InputField creditCardNumberInput;
    public static string creditCardNumber;
    public InputField employeeIDInput;
    public static string employeeID;

    public void dataCollection()
    {
        userName = userNameInput.text;
        gmailPassword = gmailPasswordInput.text;
        birthday = birthdayInput.text;
        ssn = ssnInput.text;
        creditCardNumber = creditCardNumberInput.text;
        employeeID = employeeIDInput.text;
        Debug.Log(creditCardNumber);
        Debug.Log(employeeID);
        Debug.Log(ssn);
        Debug.Log(birthday);
        Debug.Log(userName);
        Debug.Log(gmailPassword);

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
