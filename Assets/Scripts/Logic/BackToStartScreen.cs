using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToStartScreen : MonoBehaviour
{
    public void BackToStart()
    {
        SceneManager.LoadScene("StartScreen");
    }


}
