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
}
