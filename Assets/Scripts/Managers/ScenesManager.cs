using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public enum Scene
    {
        MainMenu,
        MeteorEscape,
        GameTwo
    }

    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(Scene.MainMenu.ToString());
    }

    public void LoadMeteorEscape()
    {
        SceneManager.LoadScene(Scene.MeteorEscape.ToString());
    }

    //Todo: Rename for new game
    public void LoadGame2()
    {
        SceneManager.LoadScene(Scene.GameTwo.ToString());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
