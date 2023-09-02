using UnityEngine;

/// <summary>
/// Компонент, отвечающий за фичу потребления пищи
/// </summary>
public class FoodCycleComponent : MonoBehaviour
{
    [SerializeField] Timer foodCycleTimer;
    [SerializeField] ResourcesManagerComponent resourceManager;
    [SerializeField] UnitManagerComponent unitManager;
    [SerializeField] LogComponent logComponent;

    /// <summary>
    /// Кол-во потребляемой воинами пшеницы
    /// </summary>
    [SerializeField] private int wheatPerWarrior;

    /// <summary>
    /// Кол-во потребляемой крестьянами пшеницы
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

        logComponent.AddEvent($"Цикл еды завершен. Ваши люди скушали {decreaseCount} единиц пшеницы");
    }
}
