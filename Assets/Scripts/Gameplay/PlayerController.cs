using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] _projectilePrefabs;
    [SerializeField] private Animator _playerAnimator;

    [Header("Settings")]
    [SerializeField] private float _playerSpeed;

    [Header("Bound Settings")]
    [SerializeField] private float _xBoundaryMin;
    [SerializeField] private float _xBoundaryMax;
    [SerializeField] private float _zBoundaryMin;
    [SerializeField] private float _zBoundaryMax;

    private float _horizontalInput;
    private float _verticalInput;
    private bool _hasPowerup;

    private void Update()
    {
        if (!GameManager.Instance.IsGameOver())
        {
            _horizontalInput = Input.GetAxis("Horizontal");
            _verticalInput = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(_horizontalInput, 0, _verticalInput) * _playerSpeed * Time.deltaTime;
            transform.Translate(movement, Space.World);

            Vector3 movementDirection = new Vector3(_horizontalInput, 0, _verticalInput);

            float movementSpeed = movementDirection.magnitude;

            _playerAnimator.SetFloat("Speed_f", movementSpeed, 0.1f, Time.deltaTime);


            if (movementDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
            }

            Shoot();
            ConstrainPlayerPosition();
        }
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            int projectileIndex = Random.Range(0,_projectilePrefabs.Length);
            Instantiate(_projectilePrefabs[projectileIndex], transform.position, _projectilePrefabs[projectileIndex].transform.rotation);
        }
    }

    private void ConstrainPlayerPosition()
    {
        Vector3 pos = transform.position;

        if (pos.x < _xBoundaryMin)
        {
            pos.x = _xBoundaryMin;
        }
        else if (pos.x > _xBoundaryMax)
        {
            pos.x = _xBoundaryMax;
        }

        if (pos.z < _zBoundaryMin)
        {
            pos.z = _zBoundaryMin;
        }
        else if (pos.z > _zBoundaryMax)
        {
            pos.z = _zBoundaryMax;
        }

        transform.position = pos;
    }

    public IEnumerator BoostPlayerSpeed(float boostMultiplier, float boostDuration)
    {
        if (!_hasPowerup)
        {
            _playerSpeed *= boostMultiplier;
            _hasPowerup = true;

            yield return new WaitForSeconds(boostDuration);

            _playerSpeed /= boostMultiplier;
            _hasPowerup = false;
        }
    }
}