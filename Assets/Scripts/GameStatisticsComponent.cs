using UnityEngine;

/// <summary>
/// Компонент статистики игры
/// </summary>
public class GameStatisticsComponent : MonoBehaviour
{
    /// <summary> Всего пшеницы добыто </summary>
    public int TotalWheat { get; set; }

    /// <summary> Всего воинов обучено </summary>
    public int TotalWarriors { get; set; }

    /// <summary> Всего крестьян нанято </summary>
    public int TotalPeasants { get; set; }

    /// <summary> Всего атак отражено </summary>
    public int TotalAttacks { get; set; }
}
