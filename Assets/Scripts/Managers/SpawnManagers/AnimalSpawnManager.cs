using UnityEngine;

public class AnimalSpawnManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] _animalPrefabs;

    [Header("Spawn Settings")]
    [SerializeField] private float _animalSpawnRangeX = 20;
    [SerializeField] private float _animalSpawnPosZ = 20;
    [SerializeField] private float _animalSpawnStartDelay = 2;
    [SerializeField] private float _animalSpawnRate = 1.5f;

    private void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", _animalSpawnStartDelay, _animalSpawnRate);

    }

    private void SpawnRandomAnimal()
    {
        if (GameManager.Instance.IsGameOver())
        {
            CancelInvoke("SpawnRandomAnimal");
            return;
        }
        
        int _animalIndex = Random.Range(0, _animalPrefabs.Length);
        Vector3 _randomSpawnPosition = new Vector3(Random.Range(-_animalSpawnRangeX, _animalSpawnRangeX), 0, _animalSpawnPosZ);
        Instantiate(_animalPrefabs[_animalIndex], _randomSpawnPosition, _animalPrefabs[_animalIndex].transform.rotation);
    }
}
