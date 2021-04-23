using UnityEngine;

public class Dragon : MonoBehaviour
{
    [SerializeField] private DragonData _dragonData;
    [SerializeField] private FireBallManager _fireBallManager;
    [SerializeField] private DragonHealth _dragonHealth;
    [SerializeField] private AudioClip _dragonAttackClip;
    [SerializeField] private SoundPlayer _soundPlayer;
    [SerializeField] private ParticleSystem _spawnVFX;

    public void InitializeFireBall()
    {
        _fireBallManager.SetFireBalls();
        gameObject.SetActive(false);
    }

    public void PlayDragonAttackSound()
    {
        _soundPlayer.PlaySound(_dragonAttackClip);
    }

    public void IncreaseDifficulty()
    {
        _fireBallManager.IncreaseFireBallsSpeed(_dragonData.SpeedIncrementPerArena);
        _dragonHealth.IncreaseHealth(_dragonData.HealthIncrementPerArena);
    }

    public void Spawn()
    {
        gameObject.SetActive(true);
        _spawnVFX.Play();
        _fireBallManager.EmitFireBalls();
    }
}