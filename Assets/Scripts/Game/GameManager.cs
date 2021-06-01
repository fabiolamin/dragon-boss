using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioOptions _audioOptions;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        if (PlayerPrefs.GetInt("IsFirstTime") == 0)
        {
            PlayerPrefs.SetFloat("Music", _audioOptions.MaxMusicVolume);
            PlayerPrefs.SetFloat("Sound", _audioOptions.MaxSoundVolume);

            PlayerPrefs.SetInt("IsFirstTime", 1);
        }
    }
}