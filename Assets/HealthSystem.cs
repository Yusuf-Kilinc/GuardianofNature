using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthSystem : MonoBehaviour
{
    public float Health, minHealth, MaxHealt;
    public Slider HealthSlider;
    public GameObject DeathScene;
    private bool isTakingDamage = false; // Can artýþýný durdurmak için hasar alma durumu kontrolü


    public void Start()
    {
        HealthSlider.maxValue = MaxHealt;
    }


    void Update()
    {
        HealthSlider.value = Health;
        Health = Mathf.Clamp(Health, minHealth, MaxHealt);

        // Can artýrma, hasar alýnmadýðýnda çalýþacak
        if (Health < MaxHealt && Health > minHealth && !isTakingDamage)
        {
            StartCoroutine(CanArttir());
        }

        if (Health <= minHealth)
        {
            StartCoroutine(DeathSystem());
        }
    }

    IEnumerator CanArttir()
    {
        yield return new WaitForSeconds(5); // 5 saniye bekler
        Health += 10 * Time.deltaTime;       // Yavaþça can artýrýlýr
    }

    IEnumerator DeathSystem()
    {
        yield return new WaitForSeconds(2); // 2 saniye sonra ölüm sahnesi aktif edilir
        DeathScene.SetActive(true);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Engel")
        {
            Debug.Log("Engelle çarpýþma! Hasar alýnýyor...");
            TakeDamage(5); // Engel çarpýþmasýnda can 5 azalýr
        }

        if (collision.gameObject.tag == "Death")
        {
            Debug.Log("Ölüm alanýna çarpýldý, can sýfýrlanýyor!");
            Health = 0; // Ölüm çarpýþmasýnda can sýfýrlanýr
        }
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Hasar alýnýyor: " + damage);
        isTakingDamage = true; // Can artýþýný durdurmak için hasar aldýðýnda bu deðiþken true olur

        Health -= damage; // Gelen hasar kadar can azaltýlýr
        Health = Mathf.Clamp(Health, minHealth, MaxHealt); // Can minimum ve maksimum sýnýrlar içinde tutulur

        Debug.Log("Yeni can deðeri: " + Health);

        if (Health <= 0)
        {
            Die();
        }

        isTakingDamage = false; // Hasar alma bittiðinde tekrar can artýþý baþlar
    }

    void Die()
    {
        Debug.Log("Karakter öldü!");
        StartCoroutine(DeathSystem()); // Ölüm sistemi baþlatýlýr
    }

    private void OnDrawGizmosSelected()
    {
        // Can slider'ýný görsel olarak göstermek için debug çizimleri yapýlabilir
    }
}
