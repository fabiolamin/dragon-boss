using UnityEngine;

public class Dragon : MonoBehaviour
{
    [SerializeField] private DragonData _dragonData;
    [SerializeField] private FireBallController _fireBallController;
    [SerializeField] private DragonHealth _dragonHealth;
    [SerializeField] private AudioClip _dragonAttackClip;
    [SerializeField] private SoundPlayer _soundPlayer;
    [SerializeField] private ParticleSystem _spawnVFX;

    public void InitializeFireBall()
    {
        _fireBallController.SetFireBalls();
        gameObject.SetActive(false);
    }

    public void PlayDragonAttackSound()
    {
        _soundPlayer.PlaySound(_dragonAttackClip);
    }

    public void IncreaseDifficulty()
    {
        _fireBallController.IncreaseFireBallsSpeed(_dragonData.SpeedIncrementPerArena);
        _dragonHealth.IncreaseHealth(_dragonData.HealthIncrementPerArena);
    }

    public void Spawn()
    {
        gameObject.SetActive(true);
        _spawnVFX.Play();
        _fireBallController.EmitFireBalls();
    }
}