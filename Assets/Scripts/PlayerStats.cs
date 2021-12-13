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

    private void Update()
    {
        if (lives == 0)
        {
            return;
        }
    }

    public void TakeDamage(int damage)
    {
        dmg += damage;
    }

    public void DealKnockback(Transform attacker)
    {
        rb.AddForce((this.transform.position - attacker.transform.position) * (dmg/10), ForceMode.Impulse);
    }
    
}
