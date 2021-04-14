using UnityEngine;

public class FireBallController : MonoBehaviour
{
    [SerializeField] private FireBallEmitter[] _fireBallEmitters;
    [SerializeField] private AudioClip _dragonAttackClip;
    [SerializeField] private SoundPlayer _soundPlayer;

    public void IncreaseFireBallsSpeed(float amount)
    {
        foreach (var fireBallEmitter in _fireBallEmitters)
        {
            foreach (var spell in fireBallEmitter.SpellRecycling.SpellsInstantiated)
            {
                spell.IncreaseSpeed(amount);
            }
        }
    }

    public void SetFireBalls()
    {
        foreach (var fireBallEmitter in _fireBallEmitters)
        {
            fireBallEmitter.SpellRecycling.InstantiateSpells();
        }
    }

    public void EmitFireBalls()
    {
        foreach (var fireBallEmitter in _fireBallEmitters)
        {
            StartCoroutine(fireBallEmitter.DelayToEmit());
        }
    }

    public void DeactivateSpells()
    {
        foreach (var fireBallEmitter in _fireBallEmitters)
        {
            fireBallEmitter.SpellRecycling.DeactivateSpells();
        }
    }

    public void PlayDragonAttackSound()
    {
        _soundPlayer.PlaySound(_dragonAttackClip);
    }
}
