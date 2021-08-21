using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private KeyCode shootKeyCode = KeyCode.Space;
    [SerializeField] private float shootCooldown = 1.5f;
    [SerializeField] private GameObjectPool bulletPool;

    private float _timer = 0.0f;

    void Update()
    {
        if (_timer > 0.0f)
        {
            _timer -= Time.deltaTime;
            return;
        }

        if (!Input.GetKey(shootKeyCode))
        {
            return;
        }
        
        ShootBullet();
    }

    private void ShootBullet()
    {
        _timer = shootCooldown;
        var bullet = bulletPool.GetPooledObject();
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
    }
}