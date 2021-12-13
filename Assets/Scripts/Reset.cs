using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    //public GameObject deathParticle;
    public Vector3 resetPoint;
    bool died;

    private void Start()
    {
        died = false;
        resetPoint = this.transform.position + new Vector3(0, 3.5f, 0);
    }

    void Update()
    {
        if (transform.position.y < -20)
        {
            Die();
            died = true;
        }
        else
        {
            died = false;
        }
    }

    void Die()
    {
        if (!died) { 
            PlayerStats.lives--;
            PlayerStats.dmg = 0;
            ///Instantiate(deathParticle);
            Respawn();
        }
    }

    void Respawn()
    {
        transform.position = resetPoint;
    }
}
