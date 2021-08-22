using UnityEngine;

public class EscQuit : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
