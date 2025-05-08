using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject _mainMenuUI;
    [SerializeField] Button _playButton;
    [SerializeField] Button _githubButton;
    [SerializeField] Button _linkedInButton;

    private void Start()
    {
        _playButton.onClick.AddListener(() =>
        {
            GameManager.Instance.SetGameState(GameState.Play);
            _mainMenuUI.SetActive(false);
        });

        _linkedInButton.onClick.AddListener(OpenLinkedIn);
        _githubButton.onClick.AddListener(OpenGitHub);
    }

    public void OpenGitHub()
    {
        Application.OpenURL("https://github.com/celilsens");
    }

    public void OpenLinkedIn()
    {
        Application.OpenURL("https://www.linkedin.com/in/celil-sen/");
    }
}
