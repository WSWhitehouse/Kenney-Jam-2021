using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotate : MonoBehaviour
{
    private void Update()
    {
        float h = Input.mousePosition.x - Screen.width * 0.5f;
        float v = Input.mousePosition.y - Screen.height * 0.5f;
        float angle = -Mathf.Atan2(v,h) * Mathf.Rad2Deg;
       
        transform.rotation = Quaternion.Euler (0, 0, -angle);
    }
}
