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

    /// <summary>
    /// ������� ���-�� �������
    /// </summary>
    public int WheatCount => wheatCount;

    private void Start()
    {
        SetWheatText();
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

        // TODO: set result

        SetWheatText();
    }

    private void SetWheatText()
    {
        wheatCountText.text = $"x{wheatCount}";
    }
}
