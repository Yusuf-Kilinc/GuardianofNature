using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
using System.Collections;

public class HealthSystem : MonoBehaviour
{
    public float Health,minHealth,MaxHealt;
    public Slider HealthSlider;
    Timer timer;
    void Update()
    {
        HealthSlider.value = Health;
        Health = Mathf.Clamp(Health, minHealth, MaxHealt);
        if (Health < MaxHealt)
        {
            StartCoroutine("CanArttir");
        }

        if (Health <= minHealth)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    IEnumerator CanArttir()
    {
        yield return new WaitForSeconds(5);
            Health += 1 * Time.deltaTime;

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Engel")
        {
            Health -= 25 * Time.deltaTime;
        }
    }

}
