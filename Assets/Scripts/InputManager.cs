using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public event Action InputActivated;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            InputActivated?.Invoke();
    }
}
