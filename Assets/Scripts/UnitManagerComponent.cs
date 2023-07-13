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

    /// <summary>
    /// Количество крестьян
    /// </summary>
    public int PeasantsCount => peasantsCount;

    /// <summary>
    /// Количество воинов
    /// </summary>
    public int WarriorsCount => warriorsCount;

    void Start()
    {
        UpdatePeasantsCountText();
        UpdateWarriorsCountText();
    }

    /// <summary>
    /// Увеличивает кол-во крестьян на единицу
    /// </summary>
    public void IncreasePeasantCount()
    {
        Debug.Log("Peasant ready");
        peasantsCount++;
        UpdatePeasantsCountText();
    }

    /// <summary>
    /// Увеличивает кол-во воинов на единицу
    /// </summary>
    public void IncreaseWarriorsCount()
    {
        Debug.Log("Warrior ready");
        warriorsCount++;
        UpdateWarriorsCountText();
    }

    /// <summary>
    /// Уменьшает кол-во воинов на указанное количество
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
