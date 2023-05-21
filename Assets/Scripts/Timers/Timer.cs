using System;
using UnityEngine;

/// <summary>
/// Бесконечный таймер, который запускается со старта
/// </summary>
public class Timer : MonoBehaviour
{
    [SerializeField] private bool isStarted;
    [SerializeField] private float maxTime;

    public event Action OnTimerEnded;

    private float _currentTime;

    // Start is called before the first frame update
    void Start()
    {
        _currentTime = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        _currentTime -= Time.deltaTime;

        if (_currentTime <= 0)
        {
            OnTimerEnded?.Invoke();
            _currentTime = maxTime;
        }
    }
}
