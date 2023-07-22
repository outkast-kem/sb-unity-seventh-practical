using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Компонент, отвечающий за отображение панели результатов
/// </summary>
public class ResultPanelViewComponent : MonoBehaviour
{
    [SerializeField] Text resultText;
    [SerializeField] Text statisticsText;

    [SerializeField] GameStatisticsComponent gameStatistics;

    public void SetResult(bool hasWon)
    {
        resultText.text = hasWon
            ? "Победа!"
            : "Поражение";

        statisticsText.text = $"Пшеницы добыто - {gameStatistics.TotalWheat}\n" +
                              $"Крестьян нанято - {gameStatistics.TotalPeasants}\n" +
                              $"Воинов обучено - {gameStatistics.TotalWarriors}\n" +
                              $"Атак отражено - {gameStatistics.TotalAttacks}";
    }
}
