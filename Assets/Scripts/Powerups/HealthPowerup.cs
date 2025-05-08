using UnityEngine;

public class HealthPowerup : MonoBehaviour
{
    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = FindFirstObjectByType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);

            if (_gameManager.GetHealth() < 5)
            {
                _gameManager.GainHealth();
            }
        }
    }
}
