using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ��������� �������� ����
/// </summary>
public class ResourcesManagerComponent : MonoBehaviour
{
    [SerializeField] private int wheatCount;
    [SerializeField] private Text wheatCountText;
    [SerializeField] private GameStatisticsComponent statisticsComponent;
    [SerializeField] private GameSpeedComponent gameSpeedComponent;

    [SerializeField] private int wheatToWin = 200;

    public event GameResultDelegate OnGameEnded;

    /// <summary>
    /// ������� ���-�� �������
    /// </summary>
    public int WheatCount => wheatCount;

    private void Start()
    {
        SetWheatText();
    }

    private void Update()
    {
        if (gameSpeedComponent.CurrentState == GameSpeedState.Pause)
            return;

        if (wheatCount < 0)
        {
            OnGameEnded?.Invoke(GameResults.WheatLose);
        }
        else if (wheatCount >= wheatToWin)
        {
            OnGameEnded?.Invoke(GameResults.WheatWin);
        }
    }

    /// <summary>
    /// ����������� ������� ���-�� ������� �� ��������� �����
    /// </summary>
    public void IncreaseWheat(int increaseCount)
    {
        wheatCount += increaseCount;
        statisticsComponent.TotalWheat += increaseCount;

        SetWheatText();
    }

    /// <summary>
    /// ��������� ������� ���-�� ������� �� ��������� �����
    /// </summary>
    public void DecreaseWheat(int decreaseCount)
    {
        wheatCount -= decreaseCount;

        SetWheatText();
    }

    private void SetWheatText()
    {
        wheatCountText.text = $"x{wheatCount}";
    }
}
