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
            StartCoroutine(Die());
            died = true;
        }
        else
        {
            died = false;
        }
    }

    IEnumerator Die()
    {
        if (!died) { 
            PlayerStats.lives--;
            ///Instantiate(deathParticle);
            yield return new WaitForSeconds(0.3f);
            Respawn();
        }
    }

    void Respawn()
    {
        transform.position = resetPoint;
    }
}
