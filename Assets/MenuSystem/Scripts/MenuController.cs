using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] string playScene = "SampleScene";
    [SerializeField] string mainMenuScene = "MainMenu";
    public void StartGame()
    {
        Cursor.visible = false;
        SceneManager.LoadScene(playScene);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT GAME");
        Application.Quit();
    }

}
