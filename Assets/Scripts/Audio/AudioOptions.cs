using UnityEngine;
using UnityEngine.UI;

public class AudioOptions : MonoBehaviour
{
    [SerializeField] private Slider _musicSlider, _soundsSlider;
    [SerializeField] private GameObject _optionsPanel;
    [SerializeField] private float _maxMusicVolume = 0.3f;
    [SerializeField] private float _maxSoundVolume = 0.8f;

    public float MaxMusicVolume { get { return _maxMusicVolume; } }
    public float MaxSoundVolume { get { return _maxSoundVolume; } }

    private void Start()
    {
        MusicPlayer.Instance.UpdateVolume();
        SetOptionsSliders();
    }

    private void Update()
    {
        CheckVolume();
    }

    private void SetOptionsSliders()
    {
        _musicSlider.value = PlayerPrefs.GetFloat("Music");
        _soundsSlider.value = PlayerPrefs.GetFloat("Sound");
    }
    private void CheckVolume()
    {
        if (_optionsPanel.activeSelf)
        {
            PlayerPrefs.SetFloat("Music", _musicSlider.value);
            PlayerPrefs.SetFloat("Sound", _soundsSlider.value);
            MusicPlayer.Instance.UpdateVolume();
        }
    }
}