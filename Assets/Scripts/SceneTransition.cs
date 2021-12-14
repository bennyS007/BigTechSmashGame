using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Text info;
    public  UserData data;
    public bool completedLvl01 = true;
    public bool completedLvl02 = true;
    public bool completedLvl03 = true;
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
       if(completedLvl01 && !completedLvl02 && !completedLvl03)
        {
            info.text = "You have regained your credit card number : " + data. + "\n You have regained your empolyee ID : " + data.employeeID + "\n using a VPN.";

        }
        if (completedLvl01 && completedLvl02 && !completedLvl03)
        {
            info.text = "You have now also regained your SSN : " + data.ssn + "\n You have regained your Birthday information : " + data.birthday + "\n by reading the terms and conditions before using the application.";

        }
        if (completedLvl01 && completedLvl02 && completedLvl03)
        {
            info.text = "You have now also regained your username : " + data.userName + "\n You have regained your gmail password : " + data.gmailPassword + "\n using a firewall.";

        }
        else if(!completedLvl01 && !completedLvl02 && !completedLvl03)
        {
           info.text =  "You have lost and now we can use your data for whatever we want!";
        }

    }
}
