using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserData : MonoBehaviour
{

    public InputField userNameInput;
    public string userName;

    public string dataCollection()
    {
        userName = userNameInput.text;
        Debug.Log(userName);
        return userName;
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
