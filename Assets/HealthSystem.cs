using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthSystem : MonoBehaviour
{
    public float Health, minHealth, MaxHealt;
    public Slider HealthSlider;
    public GameObject DeathScene;
    private bool isTakingDamage = false; // Can art���n� durdurmak i�in hasar alma durumu kontrol�


    public void Start()
    {
        HealthSlider.maxValue = MaxHealt;
    }


    void Update()
    {
        HealthSlider.value = Health;
        Health = Mathf.Clamp(Health, minHealth, MaxHealt);

        // Can art�rma, hasar al�nmad���nda �al��acak
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
        Health += 10 * Time.deltaTime;       // Yava��a can art�r�l�r
    }

    IEnumerator DeathSystem()
    {
        yield return new WaitForSeconds(2); // 2 saniye sonra �l�m sahnesi aktif edilir
        DeathScene.SetActive(true);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Engel")
        {
            Debug.Log("Engelle �arp��ma! Hasar al�n�yor...");
            TakeDamage(5); // Engel �arp��mas�nda can 5 azal�r
        }

        if (collision.gameObject.tag == "Death")
        {
            Debug.Log("�l�m alan�na �arp�ld�, can s�f�rlan�yor!");
            Health = 0; // �l�m �arp��mas�nda can s�f�rlan�r
        }
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Hasar al�n�yor: " + damage);
        isTakingDamage = true; // Can art���n� durdurmak i�in hasar ald���nda bu de�i�ken true olur

        Health -= damage; // Gelen hasar kadar can azalt�l�r
        Health = Mathf.Clamp(Health, minHealth, MaxHealt); // Can minimum ve maksimum s�n�rlar i�inde tutulur

        Debug.Log("Yeni can de�eri: " + Health);

        if (Health <= 0)
        {
            Die();
        }

        isTakingDamage = false; // Hasar alma bitti�inde tekrar can art��� ba�lar
    }

    void Die()
    {
        Debug.Log("Karakter �ld�!");
        StartCoroutine(DeathSystem()); // �l�m sistemi ba�lat�l�r
    }

    private void OnDrawGizmosSelected()
    {
        // Can slider'�n� g�rsel olarak g�stermek i�in debug �izimleri yap�labilir
    }
}
