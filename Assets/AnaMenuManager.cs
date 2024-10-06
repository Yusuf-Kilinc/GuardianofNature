using UnityEngine;
using UnityEngine.SceneManagement;

public class AnaMenuManager : MonoBehaviour
{
    public GameObject StartGamePanel;
    public GameObject LevelPanel;
    public int i;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LevelPanel.SetActive(false);
    }

    public void StarGame()
    {
        StartGamePanel.SetActive(false);
        LevelPanel.SetActive(true);
    }

    public void LeveltoBack()
    {
        LevelPanel.SetActive(false);
        StartGamePanel.SetActive(true);
    }

    public void DarkForest(int dgr)
    {
        SceneManager.LoadScene(dgr);
    }


    public void ExitGame()
    {
        Application.Quit();
    }

}
