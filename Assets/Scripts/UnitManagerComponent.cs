using UnityEngine;

public class UnitManagerComponent : MonoBehaviour
{
    [SerializeField] private int peasantsCount;
    [SerializeField] private int warriorsCount;

    [SerializeField] private DeferredTimer warriorCreateTimer;
    [SerializeField] private DeferredTimer peasantCreateTimer;

    // Start is called before the first frame update
    void Start()
    {
        warriorCreateTimer.OnTimerEnded += WarriorCreateTimer_OnTimerEnded;
        peasantCreateTimer.OnTimerEnded += PeasantCreateTimer_OnTimerEnded;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void PeasantCreateTimer_OnTimerEnded()
    {
        Debug.Log("Peasant ready");
        peasantsCount++;
    }

    private void WarriorCreateTimer_OnTimerEnded()
    {
        Debug.Log("Warrior ready");
        warriorsCount++;
    }
}
