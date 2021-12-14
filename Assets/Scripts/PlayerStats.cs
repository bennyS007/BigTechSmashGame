using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerStats : MonoBehaviour
{
    public int lives;
    public float dmg;
    public bool isCpu1;
    public bool isCpu2;
    public bool isCpu3;
    public Text txt;

    Rigidbody rb;
    Vector3 resetPoint;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        resetPoint = this.transform.position + new Vector3(0, 3.5f, 0);
        dmg = 0;
        lives = 3;
    }

    private void Update()
    {
        if (lives == 0)
        {
            if (isCpu1)
            {
                SceneTransition.completedLvl01 = true;
            }
            if (isCpu2)
            {
                SceneTransition.completedLvl02 = true;
            }
            if (isCpu3)
            {
                SceneTransition.completedLvl03 = true;
            }
            SceneManager.LoadSceneAsync(7);
        }

        if (transform.position.y < -20 || transform.position.y > 25)
        {
            Die();
        }

        txt.text = dmg.ToString();
    }

    public void TakeDamage(int damage)
    {
        dmg += damage;
    }

    public void DealKnockback(Transform attacker)
    {
        rb.AddForce((this.transform.position - attacker.transform.position) * (dmg/5), ForceMode.Impulse);
    }
    void Die()
    {
        lives--;
        dmg = 0;
        Respawn();
    }

    void Respawn()
    {
        transform.position = resetPoint;
    }

}
