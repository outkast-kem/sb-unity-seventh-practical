using UnityEngine;
using UnityEngine.UI;

public class UnitManagerComponent : MonoBehaviour
{
    [SerializeField] private int peasantsCount;
    [SerializeField] private int warriorsCount;

    [SerializeField] private Text peasantsCountText;
    [SerializeField] private Text warriorsCountText;

    [SerializeField] private DeferredTimer warriorCreateTimer;
    [SerializeField] private DeferredTimer peasantCreateTimer;

    public int PeasantsCount => peasantsCount;
    public int WarriorsCount => warriorsCount;

    void Start()
    {
        warriorCreateTimer.OnTimerEnded += WarriorCreateTimer_OnTimerEnded;
        peasantCreateTimer.OnTimerEnded += PeasantCreateTimer_OnTimerEnded;

        UpdatePeasantsCountText();
        UpdateWarriorsCountText();
    }

    private void Update()
    {
    }

    private void PeasantCreateTimer_OnTimerEnded()
    {
        Debug.Log("Peasant ready");
        peasantsCount++;
        UpdatePeasantsCountText();
    }

    private void WarriorCreateTimer_OnTimerEnded()
    {
        Debug.Log("Warrior ready");
        warriorsCount++;
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
