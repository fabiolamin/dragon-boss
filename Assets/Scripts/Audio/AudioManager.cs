using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;

    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _soundSource;

    [SerializeField] private AudioClip _musicThemeClip;

    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Audio Manager is NULL.");
            }

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;

        InitializeAudio();
    }

    private void InitializeAudio()
    {
        _musicSource.volume = PlayerPrefs.GetFloat("Music");
        _soundSource.volume = PlayerPrefs.GetFloat("Sound");

        PlayMusic(_musicThemeClip, true);
    }

    public void UpdateVolume(float musicVolume, float soundVolume)
    {
        _musicSource.volume = musicVolume;
        _soundSource.volume = soundVolume;

        PlayerPrefs.SetFloat("Music", musicVolume);
        PlayerPrefs.SetFloat("Sound", soundVolume);
    }

    public void PlayMusic(AudioClip audioClip, bool isLooping)
    {
        _musicSource.loop = isLooping;
        _musicSource.clip = audioClip;
        _musicSource.Play();
    }

    public void PlaySound(AudioClip audioClip)
    {
        _soundSource.clip = audioClip;
        _soundSource.Play();
    }
}