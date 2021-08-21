using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;

    private void Update()
    {
        Vector3 pos = transform.position;
        pos += transform.up * moveSpeed * Time.deltaTime;
        transform.position = pos;

        // Is not inside camera bounds
        if (!CameraBounds.Instance.Bounds.Contains(transform.position))
        {
            gameObject.SetActive(false); // Return to pool
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Asteroid"))
        {
            gameObject.SetActive(false);
        }
    }
}