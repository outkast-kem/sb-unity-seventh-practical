using System;
using UnityEngine;

/// <summary>
/// Отложенный таймер, который запускается извне и отключается по завершению
/// </summary>
public class DeferredTimer : MonoBehaviour
{
    [SerializeField] private int maxTime;

    private bool _isStarted;
    private float _currentTime;

    public event Action OnTimerEnded;

    // Start is called before the first frame update
    void Start()
    {
        _isStarted = false;
        _currentTime = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isStarted)
            return;

        _currentTime -= Time.deltaTime;

        if (_currentTime <= 0)
        {
            OnTimerEnded?.Invoke();

            _currentTime = maxTime;
            _isStarted = false;
        }
    }

    /// <summary>
    /// Запускает таймер
    /// </summary>
    public void TimerStart()
    {
        _isStarted = true;
    }
}
