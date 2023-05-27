using System;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Бесконечный таймер, который запускается со старта
/// </summary>
public class Timer : MonoBehaviour
{
    [SerializeField] private float maxTime;

    public event Action OnTimerEnded;

    private float _currentTime;
    private Image _img;

    private void Start()
    {
        _currentTime = maxTime;
        
        if (!TryGetComponent(out _img)) throw new MissingComponentException();
    }

    private void Update()
    {
        _currentTime -= Time.deltaTime;
        _img.fillAmount = _currentTime / maxTime;

        if (_currentTime <= 0)
        {
            OnTimerEnded?.Invoke();
            _currentTime = maxTime;
        }
    }
}
