using UnityEngine;

/// <summary>
/// ���������, ���������� �� ������ �� ������ � �������
/// </summary>
public class SoundComponent : MonoBehaviour
{
    [SerializeField] SoundButtonViewComponent soundButtonViewComponent;
    [SerializeField] AudioSource _backgroundAudio;

    private AudioSource _buttonClickAudio;
    private bool _isAudioEnable;

    private float _defaultVolume;

    private void Start()
    {
        _buttonClickAudio = GetComponent<AudioSource>();

        _isAudioEnable = _backgroundAudio.playOnAwake;
        _defaultVolume = _backgroundAudio.volume;

        SetImage();
    }

    /// <summary>
    /// ����������� ���� ������ ������
    /// </summary>
    public void PlayButtonClick()
    {
        _buttonClickAudio.Play();
    }

    /// <summary>
    /// �������� ��������� ��������� ������� ������
    /// </summary>
    public void ChangeAudioEnable()
    {
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
