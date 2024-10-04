using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator anim;
    public int MaxHealth = 100;
    public int currentHealth;
    public EnemyAi eai;
    public void Start()
    {
        currentHealth = MaxHealth;
    }

    public void Update()
    {
        if (eai.Walk == true)
        {
            anim.SetInteger("AnimState", 2);
        }   
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        anim.SetInteger("AnimState", 0);
        anim.SetTrigger("Death");
        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;
        Destroy(this.gameObject, 2f);
    }
}
