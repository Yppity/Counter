using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshPro _text;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.CountChanged += DisplayCountdown;
    }

    private void Start()
    {
        _text.text = "0";
    }

    private void OnDisable()
    {
        _counter.CountChanged -= DisplayCountdown;
    }

    private void DisplayCountdown()
    {
        _text.text = _counter.Count.ToString();
    }
}
