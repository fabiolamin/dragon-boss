using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer _instance;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _mainMusicClip;
    [SerializeField] private AudioClip _gameOverClip;

    public static MusicPlayer Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Music Player is NULL");
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
            DontDestroyOnLoad(this);
        }

        Initialize();
        PlayMainMusic();
        UpdateVolume();
    }

    private void Initialize()
    {
        if (PlayerPrefs.GetInt("IsFirstTime") == 0)
        {
            PlayerPrefs.SetFloat("Music", 1);
            PlayerPrefs.SetFloat("Sound", 1);

            PlayerPrefs.SetInt("IsFirstTime", 1);
        }
    }

    public void PlayMainMusic()
    {
        PlayMusic(_mainMusicClip, true);
    }

    public void PlayGameOverMusic()
    {
        PlayMusic(_gameOverClip, false);
    }

    public void UpdateVolume()
    {
        _audioSource.volume = PlayerPrefs.GetFloat("Music");
    }

    private void PlayMusic(AudioClip clip, bool isLooping)
    {
        _audioSource.clip = clip;
        _audioSource.loop = isLooping;
        _audioSource.Play();
    }
}