using UnityEngine;

/// <summary>
/// Компонент, отвечающий за работу со звуком и музыкой
/// </summary>
public class SoundComponent : MonoBehaviour
{
    [SerializeField] AudioSource _backgroundAudio;

    private AudioSource _buttonClickAudio;
    private bool _isAudioEnable;

    private void Start()
    {
        _buttonClickAudio = GetComponent<AudioSource>();

        _isAudioEnable = _buttonClickAudio.playOnAwake;
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
        if (_isAudioEnable)
            _backgroundAudio.Pause();
        else
            _backgroundAudio.Play();

        _isAudioEnable = !_isAudioEnable;
    }
}
