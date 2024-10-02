using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System.Collections;

public class HealthSystem : MonoBehaviour
{
    public float Health, minHealth, MaxHealt;
    public Slider HealthSlider;
    Timer timer;
    public GameObject DeathScene;
    public PhysicsMaterial2D pm2D;
    public float bounceForce = 5f; // Geri sekme kuvveti
    public Rigidbody2D rb;

    void Update()
    {
        HealthSlider.value = Health;
        Health = Mathf.Clamp(Health, minHealth, MaxHealt);
        if (Health < MaxHealt && Health > minHealth)
        {
            StartCoroutine("CanArttir");
        }
        if (Health <= minHealth)
        {
            StartCoroutine("DeathSystem");
        }
    }
    IEnumerator CanArttir()
    {
        yield return new WaitForSeconds(5);
        Health += 1 * Time.deltaTime;
    }
    IEnumerator DeathSystem()
    {
        yield return new WaitForSeconds(2);
        DeathScene.SetActive(true);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Engel")
        {
            Health -= 50 * Time.deltaTime;
        }
        if (collision.gameObject.tag == "Death")
        {
            Health = 0;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Engel"))
        {
            Vector2 bounceDirection = -collision.contacts[0].normal;
            rb.AddForce(bounceDirection * bounceForce, ForceMode2D.Impulse);
        }
    }
}
