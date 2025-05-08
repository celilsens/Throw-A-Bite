using UnityEngine;

public class PowerupSpawnManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] _powerupPrefabs;

    [Header("Powerup Spawn Settings")]
    [SerializeField] private float _powerupSpawnMinX = -20f;
    [SerializeField] private float _powerupSpawnMaxX = 20f;
    [SerializeField] private float _powerupSpawnMinZ = -1f;
    [SerializeField] private float _powerupSpawnMaxZ = 16f;
    [SerializeField] private float _powerupSpawnStartDelay = 2f;
    [SerializeField] private float _powerupSpawnRate = 1.5f;

    private void Start()
    {
        InvokeRepeating("SpawnPowerup", _powerupSpawnStartDelay, _powerupSpawnRate);
    }

    private void SpawnPowerup()
    {
        if (GameManager.Instance.IsGameOver())
        {
            CancelInvoke("SpawnPowerup");
            return;
        }

        int _powerupIndex = Random.Range(0, _powerupPrefabs.Length);

        Vector3 _randomSpawnPosition = new Vector3(Random.Range(_powerupSpawnMinX, _powerupSpawnMaxX), 2, Random.Range(_powerupSpawnMinZ, _powerupSpawnMaxZ));

        Instantiate(_powerupPrefabs[_powerupIndex], _randomSpawnPosition, _powerupPrefabs[_powerupIndex].transform.rotation);

    }
}
