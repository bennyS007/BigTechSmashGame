using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int lives;
    public static float dmg;

    // Start is called before the first frame update
    void Start()
    {
        dmg = 0;
        lives = 3;
    }

    
}
