using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Debris : MonoBehaviour
{
    [SerializeField] private Sprite[] asteroidSprites;
    [SerializeField] private float force = 10f;
    [SerializeField] private Vector2 speedRange = new Vector2(0.05f, 0.1f);
    [SerializeField] private Vector2 rotSpeedRange = new Vector2(-5.0f, 5.0f);
    [SerializeField] private Vector2 scaleRange = new Vector2(0.7f, 1.3f);

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;

    private Vector3 _startScale;
    private float _speed;
    private float _rotation;
    private float _timer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _spriteRenderer.sprite = asteroidSprites[Random.Range(0, asteroidSprites.Length)];
        _speed = Random.Range(speedRange.x, speedRange.y);
        _rotation = Random.Range(rotSpeedRange.x, rotSpeedRange.y);
        transform.localScale = new Vector3(Random.Range(scaleRange.x, scaleRange.y),
            Random.Range(scaleRange.x, scaleRange.y), 1);
        _timer = 0;
        _rigidbody.AddRelativeForce(new Vector2(Random.Range(-force, force), Random.Range(-force, force)),
            ForceMode2D.Impulse);
    }

    public void StartScale()
    {
        _startScale = transform.localScale;
    }

    private void Update()
    {
        if (_timer > 1.0f)
        {
            gameObject.SetActive(false);
        }

        transform.localScale = Vector3.Lerp(_startScale, new Vector3(0, 0, 1), _timer);

        var rot = transform.eulerAngles;
        rot.z += _rotation;
        transform.eulerAngles = rot;

        _timer += _speed * Time.deltaTime;
    }
}