using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Компонент ресурсов игры
/// </summary>
public class ResourcesManagerComponent : MonoBehaviour
{
    [SerializeField] private int wheatCount;
    [SerializeField] private Text wheatCountText;
    [SerializeField] private GameStatisticsComponent statisticsComponent;

    /// <summary>
    /// Текущее кол-во пшеницы
    /// </summary>
    public int WheatCount => wheatCount;

    private void Start()
    {
        SetWheatText();
    }

    /// <summary>
    /// Увеличивает текущее кол-во пшеницы на указанное число
    /// </summary>
    public void IncreaseWheat(int increaseCount)
    {
        wheatCount += increaseCount;
        statisticsComponent.TotalWheat += increaseCount;

        SetWheatText();
    }

    /// <summary>
    /// Уменьшает текущее кол-во пшеницы на указанное число
    /// </summary>
    public void DecreaseWheat(int decreaseCount)
    {
        wheatCount -= decreaseCount;

        // TODO: set result

        SetWheatText();
    }

    private void SetWheatText()
    {
        wheatCountText.text = $"x{wheatCount}";
    }
}
