using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ScaneFinish")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
