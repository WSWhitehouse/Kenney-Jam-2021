using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 5;
    [SerializeField] private float moveSpeed = 5;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 angles = transform.localEulerAngles;

        if (Input.GetKey(KeyCode.A)) // Rotate left
        {
            angles.z += rotateSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D)) // Rotate right
        {
            angles.z -= rotateSpeed* Time.deltaTime;
        }

        transform.localEulerAngles = angles;

        if (Input.GetKey(KeyCode.W)) // Move 
        {
            _rigidbody.AddRelativeForce(Vector2.up);
        }

        if (Input.GetKey(KeyCode.Space)) // Shoot
        { }
    }
}