using UnityEngine;
using UnityEngine.UI;

public class ResourcesManagerComponent : MonoBehaviour
{
    [SerializeField] private int wheatCount;
    [SerializeField] private int wheatPerPeasant;
    [SerializeField] private int wheatPerWarrior;

    [SerializeField] private Timer wheatTimer;
    [SerializeField] private Timer foodTimer;
    [SerializeField] private UnitManagerComponent unitManager;

    [SerializeField] private Text wheatCountText;

    public int WheatCount => wheatCount;

    private void Start()
    {
        wheatTimer.OnTimerEnded += WheatTimer_OnTimerEnded;
        foodTimer.OnTimerEnded += FoodTimer_OnTimerEnded;
        SetWheatText();
    }

    private void FoodTimer_OnTimerEnded()
    {
        wheatCount -= unitManager.WarriorsCount * wheatPerWarrior;
        SetWheatText();
    }

    private void WheatTimer_OnTimerEnded()
    {
        wheatCount += unitManager.PeasantsCount * wheatPerPeasant;
        SetWheatText();
    }

    private void SetWheatText()
    {
        wheatCountText.text = $"x{wheatCount}";
    }
}
