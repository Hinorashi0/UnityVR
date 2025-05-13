using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{


    [SerializeField]
    Canvas buttons;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void WinScene()
    {
        SceneManager.LoadScene(2);
    }
}
