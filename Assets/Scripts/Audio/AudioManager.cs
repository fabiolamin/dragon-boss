using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }

        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        SetMusic();
    }

    private void SetMusic()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == 0)
        {
            PlayMusic(_musicThemeClip);
        }
    }

    public void PlayMusic(AudioClip audioClip)
    {
        _musicSource.clip = audioClip;
        _musicSource.Play();
    }

    public void PlaySound(AudioClip audioClip)
    {
        _soundSource.clip = audioClip;
        _soundSource.Play();
    }

    public void UpdateVolume(float musicVolume, float soundVolume)
    {
        _musicSource.volume = musicVolume;
        _soundSource.volume = soundVolume;
    }

    public void StopMusic()
    {
        _musicSource.Stop();
    }
}