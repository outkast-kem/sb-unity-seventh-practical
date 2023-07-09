using UnityEngine;

/// <summary>
/// ���������, ���������� �� ������ �� ������ � �������
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
            _backgroundAudio.Pause();
        else
            _backgroundAudio.Play();

        _isAudioEnable = !_isAudioEnable;
    }
}
