using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    private MusicPlayer _musicPlayer;
    [SerializeField] private Slider _musicSlider, _soundsSlider;
    [SerializeField] private GameObject _optionsPanel;

    private void Start()
    {
        _musicPlayer = FindObjectOfType<MusicPlayer>();
        _musicPlayer.UpdateVolume(PlayerPrefs.GetFloat("Music"));
        SetOptionsSliders();
    }

    private void Update()
    {
        if (_optionsPanel.activeSelf)
        {
            _musicPlayer.UpdateVolume(_musicSlider.value);
        }
    }

    private void SetOptionsSliders()
    {
        _musicSlider.value = PlayerPrefs.GetFloat("Music");
        _soundsSlider.value = PlayerPrefs.GetFloat("Sounds");
    }
    public void UpdateAudioVolume()
    {
        PlayerPrefs.SetFloat("Music", _musicSlider.value);
        PlayerPrefs.SetFloat("Sounds", _soundsSlider.value);
    }
}
