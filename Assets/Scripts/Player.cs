using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100.0f;

    public float MaxHealth => maxHealth;

    public float Health { get; private set; }

    private void OnEnable()
    {
        Health = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Asteroid"))
        {
            Health -= 10.0f;
        }
    }
}