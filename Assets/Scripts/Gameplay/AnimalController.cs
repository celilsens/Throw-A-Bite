using UnityEngine;

public class AnimalController : MonoBehaviour
{
    [SerializeField] private float _speed = 40f;
    [SerializeField] private float _bottomDestroyRange = -10f;

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * _speed);

        if (transform.position.z < _bottomDestroyRange)
        {
            Destroy(gameObject);
        }
    }
}
