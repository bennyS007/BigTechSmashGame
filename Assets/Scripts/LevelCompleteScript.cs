using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelCompleteScript : MonoBehaviour
{
    public TextMeshProUGUI LevelCompleteText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LevelCompleteText.text = "Congratulations! You beat the level and have successfully protected your SSN: " + UserData.ssn + " by using a VPN!";
    }
}
