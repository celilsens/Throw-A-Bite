using UnityEngine;

public class SpeedPowerup : MonoBehaviour
{
    [Header("Powerup Settings")]
    [SerializeField] PlayerController _playerController;
    [SerializeField] float _boostPower;
    [SerializeField] float _boostDuration;

    private void Awake()
    {
        _playerController = FindFirstObjectByType<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerController.StartCoroutine(_playerController.BoostPlayerSpeed(_boostPower, _boostDuration));
            Destroy(gameObject);
        }
    }

}
