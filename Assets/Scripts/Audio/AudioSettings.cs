using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private Slider _musicSlider, _soundsSlider;
    [SerializeField] private GameObject _optionsPanel;

    private void Start()
    {
        AudioManager.Instance.UpdateVolume(PlayerPrefs.GetFloat("Music"), PlayerPrefs.GetFloat("Sounds"));
        SetOptionsSliders();
    }

    private void Update()
    {
        if (_optionsPanel.activeSelf)
        {
            AudioManager.Instance.UpdateVolume(_musicSlider.value, _soundsSlider.value);
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