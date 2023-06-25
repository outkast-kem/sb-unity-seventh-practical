using UnityEngine;

/// <summary>
/// Компонент, отвечающий за фичу сбора урожая пшеницы
/// </summary>
public class WheatHarvestCycleComponent : MonoBehaviour
{
    [SerializeField] Timer wheatHarvestTimer;
    [SerializeField] UnitManagerComponent unitManager;
    [SerializeField] ResourcesManagerComponent resourcesManager;

    /// <summary>
    /// Кол-во собираемой крестьянином за цикл пшеницы
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
