using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private InputManager _inputManager;

    private float _delay = 0.5f;
    private bool _isCotoutineRunning;
    private Coroutine _coroutine;

    public event Action CountChanged;

    public int Count { get; private set; } = 0;

    private void OnEnable()
    {
        _inputManager.InputActivated += ToggleCoroutine;
    }

    private void OnDisable()
    {
        _inputManager.InputActivated -= ToggleCoroutine;
    }

    private void ToggleCoroutine()
    {
        if (_isCotoutineRunning == false)
        {
            _isCotoutineRunning = true;
            _coroutine = StartCoroutine(IncreaseCountRoutine(_delay));
        }
        else
        {
            _isCotoutineRunning = false;
            StopCoroutine(_coroutine);
        }
    }

    private IEnumerator IncreaseCountRoutine(float delay)
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