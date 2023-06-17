using System;
using UnityEngine;

/// <summary>
/// ���������� ������, ������� ����������� ����� � ����������� �� ����������
/// </summary>
public class DeferredTimer : MonoBehaviour
{
    [SerializeField] private int maxTime;

    private bool _isStarted;
    private float _currentTime;

    public delegate void TickDelegate(float leftTime);

    public event Action OnTimerEnded;
    public event TickDelegate OnTick;

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

        var leftTime = _currentTime / maxTime;
        OnTick?.Invoke(leftTime);

        if (_currentTime <= 0)
        {
            OnTimerEnded?.Invoke();

            _currentTime = maxTime;
            _isStarted = false;
        }
    }

    /// <summary>
    /// ��������� ������
    /// </summary>
    public void TimerStart()
    {
        _isStarted = true;
    }
}
