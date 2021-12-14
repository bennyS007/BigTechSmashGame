using UnityEngine;
using UnityEngine.UI;


public class PlayerStats : MonoBehaviour
{
    public int lives;
    public float dmg;
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
            return;
        }

        if (transform.position.y < -20)
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
        rb.AddForce((this.transform.position - attacker.transform.position) * (dmg/10), ForceMode.Impulse);
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
