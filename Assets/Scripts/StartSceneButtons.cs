using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneButtons : MonoBehaviour
{
    public void OnStartButtonPressed()
    {
        SceneManager.LoadSceneAsync("Main", LoadSceneMode.Single);
    }

    public void OnHowToPlayPressed()
    {
        // Nothing for now.
    }

    public void OnExitPressed()
    {
        Application.Quit();
    }
}
