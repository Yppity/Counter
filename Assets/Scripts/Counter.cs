using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public int Count { get; private set; } = 0;
    public event Action CountChanged;

    [SerializeField] private InputManager _inputManager;

    private float _delay = 0.5f;
    private bool _isCotoutineRunning;
    private Coroutine _coroutine;


    private void OnEnable()
    {
        _inputManager.LeftMouseButtonDown += ToggleCoroutine;
    }

    private void OnDisable()
    {
        _inputManager.LeftMouseButtonDown -= ToggleCoroutine;
    }

    private void ToggleCoroutine()
    {
        if (_isCotoutineRunning == false)
        {
            _isCotoutineRunning = true;
            _coroutine = StartCoroutine(CountTime(_delay));
        }
        else
        {
            _isCotoutineRunning = false;
            StopCoroutine(_coroutine);
        }
    }

    private IEnumerator CountTime(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (true)
        {
            Count++;
            CountChanged?.Invoke();
            yield return wait;
        }
    }
}