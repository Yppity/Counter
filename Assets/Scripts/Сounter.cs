using System.Collections;
using TMPro;
using UnityEngine;

public class Сounter : MonoBehaviour
{
    [SerializeField] private TextMeshPro _text;

    private float _delay = 0.5f;
    private bool _isCotoutineRunning;
    private int _count = 0;
    private Coroutine _coroutine;

    private void Start()
    {
        _text.text = "0";
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
    }

    private IEnumerator CountTime(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (true)
        {
            _count++;
            DisplayCountdown(_count);
            yield return wait;
        }
    }

    private void DisplayCountdown(int count)
    {
        _text.text = count.ToString();
    }
}
