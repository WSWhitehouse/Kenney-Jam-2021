using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputRotate : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 5;

    [Space, SerializeField] private KeyCode leftKeyCode = KeyCode.A;
    [SerializeField] private KeyCode rightKeyCode = KeyCode.D;


    void Update()
    {
        Vector3 angles = transform.localEulerAngles;
        if (Input.GetKey(leftKeyCode))
        {
            angles.z += rotateSpeed * Time.deltaTime;
        }

        if (Input.GetKey(rightKeyCode))
        {
            angles.z -= rotateSpeed * Time.deltaTime;
        }

        transform.localEulerAngles = angles;
    }
}