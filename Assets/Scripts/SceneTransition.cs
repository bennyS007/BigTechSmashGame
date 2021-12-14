using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Text info;
    public static bool completedLvl01 = false;
    public static bool completedLvl02 = false;
    public static bool completedLvl03 = false;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
       if(completedLvl01 && !completedLvl02 && !completedLvl03)
        {
            info.text = "You have regained your credit card number : " + UserData.creditCardNumber + "\n You have regained your empolyee ID : " + UserData.employeeID + "\n using a VPN.";

        }
        if (completedLvl01 && completedLvl02 && !completedLvl03)
        {
            info.text = "You have now also regained your SSN : " + UserData.ssn + "\n You have regained your Birthday information : " + UserData.birthday + "\n by reading the terms and conditions before using the application.";

        }
        if (completedLvl01 && completedLvl02 && completedLvl03)
        {
            info.text = "You have now also regained your username : " + UserData.userName + "\n You have regained your gmail password : " + UserData.gmailPassword + "\n using a firewall.";

        }
        else if(!completedLvl01 && !completedLvl02 && !completedLvl03)
        {
           info.text =  "You have lost and now we can use your data for whatever we want!";
        }

    }
}
