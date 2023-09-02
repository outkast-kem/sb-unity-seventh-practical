using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ��������� ������ � �������
/// </summary>
public class UnitManagerComponent : MonoBehaviour
{
    [SerializeField] private int peasantsCount;
    [SerializeField] private int warriorsCount;
    [SerializeField] private int peasantsToWin = 70;

    [SerializeField] private Text peasantsCountText;
    [SerializeField] private Text warriorsCountText;

    [SerializeField] private GameStatisticsComponent statisticsComponent;
    [SerializeField] private GameSpeedComponent gameSpeedComponent;

    public event GameResultDelegate OnGameEnded;

    /// <summary>
    /// ������� ���������� ��������
    /// </summary>
    public int PeasantsCount => peasantsCount;

    /// <summary>
    /// ������� ���������� ������
    /// </summary>
    public int WarriorsCount => warriorsCount;

    private void Start()
    {
        UpdatePeasantsCountText();
        UpdateWarriorsCountText();
    }

    private void Update()
    {
        if (gameSpeedComponent.CurrentState == GameSpeedState.Pause)
            return;

        if (warriorsCount < 0)
        {
            OnGameEnded?.Invoke(GameResults.BattleLose);
        }    
        else if (peasantsCount >= peasantsToWin)
        {
            OnGameEnded?.Invoke(GameResults.PeasantsWin);
        }
    }

    /// <summary>
    /// ����������� ������� ���-�� �������� �� �������
    /// </summary>
    public void IncreasePeasantCount()
    {
        peasantsCount++;
        statisticsComponent.TotalPeasants++;

        UpdatePeasantsCountText();
    }

    /// <summary>
    /// ����������� ������� ���-�� ������ �� �������
    /// </summary>
    public void IncreaseWarriorsCount()
    {
        warriorsCount++;
        statisticsComponent.TotalWarriors++;

        UpdateWarriorsCountText();
    }

    /// <summary>
    /// ��������� ������� ���-�� ������ �� ��������� ����������
    /// </summary>
    public void DecreaseWarriorsCount(int decreaseCount)
    {
        warriorsCount -= decreaseCount;
        UpdateWarriorsCountText();
    }

    private void UpdatePeasantsCountText()
    {
        peasantsCountText.text = $"x{peasantsCount}";
    }

    private void UpdateWarriorsCountText()
    {
        warriorsCountText.text = $"x{warriorsCount}";
    }
}
