using UnityEngine;

/// <summary>
/// Компонент, отвечающий за работу со звуком и музыкой
/// </summary>
public class SoundComponent : MonoBehaviour
{
    [SerializeField] SoundButtonViewComponent soundButtonViewComponent;
    [SerializeField] AudioSource _backgroundAudio;

    private AudioSource _buttonClickAudio;
    private bool _isAudioEnable;

    private float _defaultVolume;

    private void Awake()
    {
        _buttonClickAudio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _isAudioEnable = _backgroundAudio.playOnAwake;
        _defaultVolume = _backgroundAudio.volume;

        SetImage();
    }

    /// <summary>
    /// Проигрывает звук щелчка кнопки
    /// </summary>
    public void PlayButtonClick()
    {
        _buttonClickAudio.Play();
    }

    /// <summary>
    /// Изменить состояния проигрыша фоновой музыки
    /// </summary>
    public void ChangeAudioEnable()
    {
        if (!_backgroundAudio.isPlaying)
            _backgroundAudio.Play();

        if (_isAudioEnable)
            _backgroundAudio.volume = 0;
        else
            _backgroundAudio.volume = _defaultVolume;

        _isAudioEnable = !_isAudioEnable;

        SetImage();
    }

    private void SetImage()
    {
        soundButtonViewComponent.SetSprite(_isAudioEnable);
    }
}
