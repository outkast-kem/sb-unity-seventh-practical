using UnityEngine;
using UnityEngine.UI;

public class SoundButtonViewComponent : MonoBehaviour
{
    [SerializeField] Sprite soundOnImage;
    [SerializeField] Sprite soundOffImage;

    private Image _buttonImage;

    private void Awake()
    {
        _buttonImage = GetComponent<Image>();
    }

    public void SetSprite(bool isSoundEnable)
    {
        _buttonImage.sprite = isSoundEnable
            ? soundOnImage
            : soundOffImage;
    }
}
