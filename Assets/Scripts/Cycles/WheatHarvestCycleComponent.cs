using UnityEngine;

/// <summary>
/// ���������, ���������� �� ���� ����� ������ �������
/// </summary>
public class WheatHarvestCycleComponent : MonoBehaviour
{
    [SerializeField] Timer wheatHarvestTimer;
    [SerializeField] UnitManagerComponent unitManager;
    [SerializeField] ResourcesManagerComponent resourcesManager;

    /// <summary>
    /// ���-�� ���������� ������������ �� ���� �������
    /// </summary>
    [SerializeField] int wheatPerPeasant;

    private void Start()
    {
        wheatHarvestTimer.OnTimerEnded += WheatHarvestTimer_OnTimerEnded;
    }

    private void WheatHarvestTimer_OnTimerEnded()
    {
        var wheatCount = unitManager.PeasantsCount * wheatPerPeasant;
        resourcesManager.IncreaseWheat(wheatCount);
    }
}
