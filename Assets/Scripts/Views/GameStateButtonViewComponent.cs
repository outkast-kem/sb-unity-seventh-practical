using UnityEngine;
using UnityEngine.UI;

/// <summary>
///  омпонент, отвечающий за отображение кнопок настроек скорости игры
/// </summary>
public class GameStateButtonViewComponent : MonoBehaviour
{
    private Image _buttonImage;

    private Color ActiveColor => new(0, 255, 122);
    private Color NormalColor => Color.white;

    private void Start()
    {
        _buttonImage = GetComponent<Image>();
    }

    public void SetEnabled()
    {
        _buttonImage.color = ActiveColor;
    }

    public void SetDisabled()
    {
        _buttonImage.color = NormalColor;
    }
}
