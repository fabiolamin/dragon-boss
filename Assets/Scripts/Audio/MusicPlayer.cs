using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        int musicPlayers = FindObjectsOfType<MusicPlayer>().Length;

        if (musicPlayers > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);
    }

    public void UpdateVolume(float value)
    {
        _audioSource.volume = value;
    }
}
