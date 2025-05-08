using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _gameOverScoreText;
    [SerializeField] private GameObject _gameOverUI;
    [SerializeField] private GameObject _mainMenuUI;

    [Header("Settings")]
    [SerializeField] private int _currentHealth;
    [SerializeField] private int _maxHealth = 5;
    [SerializeField] private int _scoreToAdd;

    private float _currentScore = 0;
    private bool _isGameOver;

    public static GameManager Instance;
    public GameState CurrentState { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SetGameState(GameState.Pause);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GetObjets();
        PrepareScene();
        UpdateUI();
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {
            Destroy(other.gameObject);
            LoseHealth();
        }

        if (_currentHealth <= 0)
        {
            SetGameState(GameState.GameOver);
            _healthText.text = "Health: 0 :/";
            _gameOverScoreText.text = "Your Score: " + _currentScore.ToString();
            _gameOverUI.SetActive(true);
        }
    }
    private void GetObjets()
    {
        _mainMenuUI = GameObject.Find("MainMenuUI");
        _healthText = GameObject.Find("PlayerUIHealthText").GetComponent<TMP_Text>();
        _scoreText = GameObject.Find("PlayerUIScoreText").GetComponent<TMP_Text>();
        _gameOverScoreText = GameObject.Find("GameOverScoreText").GetComponent<TMP_Text>();
        _gameOverUI = GameObject.Find("GameOverUI");
    }

    private void PrepareScene()
    {
        _gameOverUI.SetActive(false);
        _currentHealth = _maxHealth;
        _currentScore = 0;
    }

    private void UpdateUI()
    {
        _healthText.text = "Health: " + _currentHealth;
        _scoreText.text = "Score: " + _currentScore.ToString();
    }

    public void SetGameState(GameState newState)
    {
        CurrentState = newState;

        switch (CurrentState)
        {
            case GameState.Play:
                Time.timeScale = 1f;
                _isGameOver = false;
                break;

            case GameState.Pause:
                Time.timeScale = 0f;
                break;

            case GameState.Resume:
                Time.timeScale = 1f;
                break;

            case GameState.GameOver:
                Time.timeScale = 0f;
                _isGameOver = true;
                break;
        }
    }

    public void AddScore()
    {
        _currentScore += _scoreToAdd;
        _scoreText.text = "Score: " + _currentScore.ToString();
    }

    public int GetHealth()
    {
        return _currentHealth;
    }

    public void GainHealth()
    {
        _currentHealth++;
        _healthText.text = "Health: " + _currentHealth;
    }

    public void LoseHealth()
    {
        _currentHealth--;
        _healthText.text = "Health: " + _currentHealth;
    }

    public bool IsGameOver()
    {
        return _isGameOver;
    }
}
