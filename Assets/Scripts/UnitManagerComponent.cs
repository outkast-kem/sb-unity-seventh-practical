using UnityEngine;
using UnityEngine.UI;

public class UnitManagerComponent : MonoBehaviour
{
    [SerializeField] private int peasantsCount;
    [SerializeField] private int warriorsCount;

    [SerializeField] private Text peasantsCountText;
    [SerializeField] private Text warriorsCountText;

    public int PeasantsCount => peasantsCount;
    public int WarriorsCount => warriorsCount;

    void Start()
    {
        UpdatePeasantsCountText();
        UpdateWarriorsCountText();
    }

    private void Update()
    {
    }

    public void IncreasePeasantCount()
    {
        Debug.Log("Peasant ready");
        peasantsCount++;
        UpdatePeasantsCountText();
    }

    public void IncreaseWarriorsCount()
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
