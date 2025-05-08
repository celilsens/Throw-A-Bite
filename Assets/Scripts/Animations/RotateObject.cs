using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private Vector3 _rotateVector;

    private void Update()
    {
        if (!GameManager.Instance.IsGameOver())
        {
            transform.Rotate(_rotateVector);
        }
    }
}
