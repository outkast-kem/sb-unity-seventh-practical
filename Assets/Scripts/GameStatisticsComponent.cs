using UnityEngine;

/// <summary>
/// ��������� ���������� ����
/// </summary>
public class GameStatisticsComponent : MonoBehaviour
{
    /// <summary> ����� ������� ������ </summary>
    public int TotalWheat { get; set; }

    /// <summary> ����� ������ ������� </summary>
    public int TotalWarriors { get; set; }

    /// <summary> ����� �������� ������ </summary>
    public int TotalPeasants { get; set; }

    /// <summary> ����� ���� �������� </summary>
    public int TotalAttacks { get; set; }
}
