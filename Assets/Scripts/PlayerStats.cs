using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int lives;
    public static float dmg;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        dmg = 0;
        lives = 3;
    }

    public void TakeDamage(int damage)
    {
        dmg += damage;
    }
    
}
