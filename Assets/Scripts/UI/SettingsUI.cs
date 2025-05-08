using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject _settingsUI;
    [SerializeField] Button _settingsButton;
    [SerializeField] Button _resumeButton;
    [SerializeField] Button _restartButton;
    // [SerializeField] Button _returnToMenuButton;

    private bool _isPaused = false;

    private void Start()
    {
        _settingsButton.onClick.AddListener(TogglePause);
        _resumeButton.onClick.AddListener(ResumeGame);
        _restartButton.onClick.AddListener(RestartGame);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        if (_isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    private void PauseGame()
    {
        GameManager.Instance.SetGameState(GameState.Pause);
        _settingsUI.SetActive(true);
        _isPaused = true;
        Time.timeScale = 0f;
    }

    private void ResumeGame()
    {
        GameManager.Instance.SetGameState(GameState.Resume);
        _settingsUI.SetActive(false);
        _isPaused = false;
        Time.timeScale = 1f;
    }

    private void RestartGame()
    {
        Destroy(GameManager.Instance.gameObject);
        Time.timeScale = 1f;
        _isPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
