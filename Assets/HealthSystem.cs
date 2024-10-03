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
            Health -= 5 /** Time.deltaTime*/;
        }
        if (collision.gameObject.tag == "Death")
        {
            Health = 0;
        }
    }
}
