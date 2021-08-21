using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100.0f;

    private float _health;

    private void OnEnable()
    {
        _health = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Asteroid"))
        {
            _health -= 10.0f;
        }
    }
}