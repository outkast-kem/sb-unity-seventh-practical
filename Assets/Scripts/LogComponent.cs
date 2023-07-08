using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Компонент, отвечающий за фичу сбора логов
/// </summary>
public class LogComponent : MonoBehaviour
{
    [SerializeField] Text currentLogText;
    [SerializeField] Text historyLogsText;

    private const int MAX_LOG_COUNT = 4;

    private LinkedList<string> _events;
    private string _currentLog; 

    private void Start()
    {
        _events = new LinkedList<string>();
        VisualizeLogs();
    }

    /// <summary>
    /// Добавить событие в список событий. В списке не может быть больше <see cref="MAX_LOG_COUNT"/> записей,
    /// поэтому по достижении этого числа, события начинают удаляться
    /// </summary>
    public void AddEvent(string ev)
    {
        if (!string.IsNullOrEmpty(_currentLog))
            _events.AddLast(_currentLog);            

        if (_events.Count > MAX_LOG_COUNT)
            _events.RemoveFirst();

        _currentLog = ev;

        VisualizeLogs();
    }

    private void VisualizeLogs()
    {
        var stringBuilder = new StringBuilder();

        foreach (var ev in _events)
        {
            stringBuilder.Insert(0, ev + "\n");
        }

        currentLogText.text = _currentLog;
        historyLogsText.text = stringBuilder.ToString();
    }
}
