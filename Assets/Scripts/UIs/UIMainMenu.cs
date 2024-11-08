using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{

    [SerializeField] Button _meteorEscapeBtn;
    [SerializeField] Button _gameTwoBtn;
    [SerializeField] Button _quitGameBtn;

    void Start()
    {
        _meteorEscapeBtn.onClick.AddListener(StartMeteorEscape);
        _gameTwoBtn.onClick.AddListener(StartGameTwo);
        _quitGameBtn.onClick.AddListener(QuitGame);
    }

    private void StartMeteorEscape()
    {
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.MeteorEscape);
    }

    private void StartGameTwo()
    {
        ScenesManager.Instance.LoadGame2();
    }

    private void QuitGame()
    {
        ScenesManager.Instance.QuitGame();
    }
}
