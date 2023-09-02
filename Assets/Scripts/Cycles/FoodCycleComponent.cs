using UnityEngine;

/// <summary>
/// ���������, ���������� �� ���� ����������� ����
/// </summary>
public class FoodCycleComponent : MonoBehaviour
{
    [SerializeField] Timer foodCycleTimer;
    [SerializeField] ResourcesManagerComponent resourceManager;
    [SerializeField] UnitManagerComponent unitManager;
    [SerializeField] LogComponent logComponent;

    /// <summary>
    /// ���-�� ������������ ������� �������
    /// </summary>
    [SerializeField] private int wheatPerWarrior;

    /// <summary>
    /// ���-�� ������������ ����������� �������
    /// </summary>
    [SerializeField] private int wheatPerPeasant;

    private void Start()
    {
        foodCycleTimer.OnTimerEnded += FoodCycleTimer_OnTimerEnded;
    }

    private void FoodCycleTimer_OnTimerEnded()
    {
        var decreaseCount = unitManager.WarriorsCount * wheatPerWarrior + unitManager.PeasantsCount * wheatPerPeasant;
        resourceManager.DecreaseWheat(decreaseCount);

        logComponent.AddEvent($"���� ��� ��������. ���� ���� ������� {decreaseCount} ������ �������");
    }
}
