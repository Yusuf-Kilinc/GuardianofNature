using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ScaneFinish")
        {
            Debug.Log("Degdi");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
