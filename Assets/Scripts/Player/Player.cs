using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private ParticleSystem _bonusVFX;
    [SerializeField] private AudioClip _bonusClip;
    [SerializeField] private SoundPlayer _soundPlayer;

    public PlayerData PlayerData { get { return _playerData; } }

    public void PlayBonusEffects()
    {
        _soundPlayer.PlaySound(_bonusClip);
        _bonusVFX.Play();
    }
}