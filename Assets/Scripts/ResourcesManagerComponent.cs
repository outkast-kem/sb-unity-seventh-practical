using UnityEngine;
using UnityEngine.UI;

public class ResourcesManagerComponent : MonoBehaviour
{
    [SerializeField] private int wheatCount;

    [SerializeField] private Text wheatCountText;

    public int WheatCount => wheatCount;

    private void Start()
    {
        SetWheatText();
    }

    public void IncreaseWheat(int increaseCount)
    {
        wheatCount += increaseCount;
        SetWheatText();
    }

    public void DecreaseWheat(int decreaseCount)
    {
        wheatCount -= decreaseCount;
        SetWheatText();
    }

    private void SetWheatText()
    {
        wheatCountText.text = $"x{wheatCount}";
    }
}
