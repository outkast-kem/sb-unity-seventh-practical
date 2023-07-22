using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Компонент работы с юнитами
/// </summary>
public class UnitManagerComponent : MonoBehaviour
{
    [SerializeField] private int peasantsCount;
    [SerializeField] private int warriorsCount;

    [SerializeField] private Text peasantsCountText;
    [SerializeField] private Text warriorsCountText;

    [SerializeField] private GameStatisticsComponent statisticsComponent;

    /// <summary>
    /// Текущее количество крестьян
    /// </summary>
    public int PeasantsCount => peasantsCount;

    /// <summary>
    /// Текущее количество воинов
    /// </summary>
    public int WarriorsCount => warriorsCount;

    void Start()
    {
        UpdatePeasantsCountText();
        UpdateWarriorsCountText();
    }

    /// <summary>
    /// Увеличивает текущее кол-во крестьян на единицу
    /// </summary>
    public void IncreasePeasantCount()
    {
        peasantsCount++;
        statisticsComponent.TotalPeasants++;

        UpdatePeasantsCountText();
    }

    /// <summary>
    /// Увеличивает текущее кол-во воинов на единицу
    /// </summary>
    public void IncreaseWarriorsCount()
    {
        warriorsCount++;
        statisticsComponent.TotalWarriors++;

        UpdateWarriorsCountText();
    }

    /// <summary>
    /// Уменьшает текущее кол-во воинов на указанное количество
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
