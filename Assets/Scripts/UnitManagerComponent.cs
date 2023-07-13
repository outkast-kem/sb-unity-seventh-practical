using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ��������� ������ � �������
/// </summary>
public class UnitManagerComponent : MonoBehaviour
{
    [SerializeField] private int peasantsCount;
    [SerializeField] private int warriorsCount;

    [SerializeField] private Text peasantsCountText;
    [SerializeField] private Text warriorsCountText;

    /// <summary>
    /// ���������� ��������
    /// </summary>
    public int PeasantsCount => peasantsCount;

    /// <summary>
    /// ���������� ������
    /// </summary>
    public int WarriorsCount => warriorsCount;

    void Start()
    {
        UpdatePeasantsCountText();
        UpdateWarriorsCountText();
    }

    /// <summary>
    /// ����������� ���-�� �������� �� �������
    /// </summary>
    public void IncreasePeasantCount()
    {
        Debug.Log("Peasant ready");
        peasantsCount++;
        UpdatePeasantsCountText();
    }

    /// <summary>
    /// ����������� ���-�� ������ �� �������
    /// </summary>
    public void IncreaseWarriorsCount()
    {
        Debug.Log("Warrior ready");
        warriorsCount++;
        UpdateWarriorsCountText();
    }

    /// <summary>
    /// ��������� ���-�� ������ �� ��������� ����������
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
