using UnityEngine;

public class Dragon : MonoBehaviour
{
    [SerializeField] private AudioClip _dragonAttackClip;
    [SerializeField] private SoundPlayer _soundPlayer;

    public void PlayDragonAttackSound()
    {
        _soundPlayer.PlaySound(_dragonAttackClip);
    }
}