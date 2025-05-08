using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] GameObject _gameOverUI;
    [SerializeField] Button _tryAgainButton;
    // [SerializeField] Button _returnToMenuButton;

    private void Start()
    {
        _tryAgainButton.onClick.AddListener(ReloadCurrentScene);
        // _returnToMenuButton.onClick.AddListener(ReturnToMenu);
    }

    private void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameManager.Instance.SetGameState(GameState.Play);
    }

    // private void ReturnToMenu()
    // {
    //     SceneManager.LoadScene(Consts.SceneNames.THROW_A_BITE_MENU_SCENE);
    // }
}
