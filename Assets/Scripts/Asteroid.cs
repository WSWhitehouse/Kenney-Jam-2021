using UnityEngine;
using Random = UnityEngine.Random;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private Sprite[] asteroidSprites;
    [SerializeField] private Vector2 targetRange = new Vector2(10f, 10f);
    [SerializeField] private Vector2 speedRange = new Vector2(0.02f, 0.075f);
    [SerializeField] private Vector2 rotSpeedRange = new Vector2(-5.0f, 5.0f);
    [SerializeField] private Vector2 scaleRange = new Vector2(0.7f, 1.3f);

    private SpriteRenderer _spriteRenderer;

    private Vector3 _startPos;
    private Vector3 _target;
    private float _speed;
    private float _rotation;
    private float _timer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _spriteRenderer.sprite = asteroidSprites[Random.Range(0, asteroidSprites.Length)];
        _speed = Random.Range(speedRange.x, speedRange.y);
        _rotation = Random.Range(rotSpeedRange.x, rotSpeedRange.y);

        _target = new Vector3(Random.Range(targetRange.x, targetRange.y),
            Random.Range(targetRange.x, targetRange.y),
            0);
        transform.localScale = new Vector3(Random.Range(scaleRange.x, scaleRange.y),
            Random.Range(scaleRange.x, scaleRange.y), 1);
        _timer = 0;
    }

    public void StartMovement()
    {
        _startPos = transform.position;
    }

    private void Update()
    {
        if (_timer > 1.0f)
        {
            // if object is in final target pos, deactivate it
            // this should not trigger but its just in case
            gameObject.SetActive(false);
        }

        transform.position = Vector3.Lerp(_startPos, _target, _timer);

        var rot = transform.eulerAngles;
        rot.z += _rotation;
        transform.eulerAngles = rot;

        _timer += _speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        gameObject.SetActive(false);
        AsteroidDebris.Instance.CreateDebris(transform.position);
    }
}