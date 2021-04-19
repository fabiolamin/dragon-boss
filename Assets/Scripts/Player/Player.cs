using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private ParticleSystem _bonusVFX;
    [SerializeField] private AudioClip _bonusClip;
    [SerializeField] private SoundPlayer _soundPlayer;

    public void PlayBonusEffects()
    {
        _soundPlayer.PlaySound(_bonusClip);
        _bonusVFX.Play();
    }
}