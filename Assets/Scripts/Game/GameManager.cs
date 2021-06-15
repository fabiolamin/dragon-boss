using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioOptions _audioOptions;
    [SerializeField] private SceneLoader _sceneLoader;

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

    public void PlayGame()
    {
        _sceneLoader.LoadScene(2);
    }
}