using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }

    public void SinglePlayer()
    {
        SceneManager.LoadScene("ActiveGame");
    }

    public void MultiPlayer()
    {

    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void Options()
    {

    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
}
