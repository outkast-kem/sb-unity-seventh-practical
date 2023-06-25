using UnityEngine;

/// <summary>
/// Компонент, отвечающий за фичу потребления пищи
/// </summary>
public class FoodCycleComponent : MonoBehaviour
{
    [SerializeField] Timer foodCycleTimer;
    [SerializeField] ResourcesManagerComponent resourceManager;
    [SerializeField] UnitManagerComponent unitManager;

    /// <summary>
    /// Кол-во потребляемой воинами пшеницы
    /// </summary>
    [SerializeField] private int wheatPerWarrior;

    private void Start()
    {
        foodCycleTimer.OnTimerEnded += FoodCycleTimer_OnTimerEnded;
    }

    private void FoodCycleTimer_OnTimerEnded()
    {
        var decreaseCount = unitManager.WarriorsCount * wheatPerWarrior;
        resourceManager.DecreaseWheat(decreaseCount);
    }
}
