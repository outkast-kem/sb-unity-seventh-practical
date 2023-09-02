using UnityEngine;

/// <summary>
/// Компонент, отвечающий за работу со звуком и музыкой
/// </summary>
public class SoundComponent : MonoBehaviour
{
    [SerializeField] SoundButtonViewComponent soundButtonViewComponent;
    [SerializeField] AudioSource backgroundAudio;
    [SerializeField] AudioSource winAudio;
    [SerializeField] AudioSource loseAudio;

    private AudioSource _buttonClickAudio;
    private bool _isAudioEnable;

    private float _defaultVolume;

    private void Awake()
    {
        _buttonClickAudio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _isAudioEnable = backgroundAudio.playOnAwake;
        _defaultVolume = backgroundAudio.volume;

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
        if (!backgroundAudio.isPlaying)
            backgroundAudio.Play();

        if (_isAudioEnable)
            backgroundAudio.volume = 0;
        else
            backgroundAudio.volume = _defaultVolume;

        _isAudioEnable = !_isAudioEnable;

        SetImage();
    }

    public void PlayWin()
    {
        winAudio.PlayDelayed(1);
    }

    public void PlayLose()
    {
        loseAudio.PlayDelayed(1);
    }

    private void SetImage()
    {
        soundButtonViewComponent.SetSprite(_isAudioEnable);
    }
}
