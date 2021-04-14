using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    public void PlaySound(AudioClip clip)
    {
        _audioSource.clip = clip;
        _audioSource.volume = PlayerPrefs.GetFloat("Sound");
        _audioSource.Play();
    }
}