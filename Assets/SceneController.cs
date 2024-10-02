using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public int i;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ScaneFinish")
        {
            SceneManager.LoadScene(i);
        }
        
        //if (other.gameObject.tag == "ScaneFinish")
        //{
        //    Debug.Log("Degdi");
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //}
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
