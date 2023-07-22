using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ���������, ���������� �� ����������� ������ �����������
/// </summary>
public class ResultPanelViewComponent : MonoBehaviour
{
    [SerializeField] Text resultText;
    [SerializeField] Text statisticsText;

    [SerializeField] GameStatisticsComponent gameStatistics;

    public void SetResult(bool hasWon)
    {
        resultText.text = hasWon
            ? "������!"
            : "���������";

        statisticsText.text = $"������� ������ - {gameStatistics.TotalWheat}\n" +
                              $"�������� ������ - {gameStatistics.TotalPeasants}\n" +
                              $"������ ������� - {gameStatistics.TotalWarriors}\n" +
                              $"���� �������� - {gameStatistics.TotalAttacks}";
    }
}
