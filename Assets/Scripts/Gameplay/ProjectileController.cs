using TMPro;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [Header("Projectile Settings")]
    [SerializeField] private float _projectileSpeed = 40f;
    [SerializeField] private float _topDestroyRange = 20f;

    private void Update()
    {
        MoveObject();
        DestroyOutOfBounds();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            GameManager.Instance.AddScore();
        }
    }

    private void MoveObject()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * _projectileSpeed);
    }

    private void DestroyOutOfBounds()
    {
        if (transform.position.z > _topDestroyRange)
        {
            Destroy(gameObject);
        }
    }
}
