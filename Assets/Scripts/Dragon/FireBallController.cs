using UnityEngine;

public class FireBallController : MonoBehaviour
{
    [SerializeField] private FireBallEmitter[] _fireBallEmitters;

    public void IncreaseFireBallsSpeed(float amount)
    {
        foreach (var fireBallEmitter in _fireBallEmitters)
        {
            foreach (var spell in fireBallEmitter.SpellRecycling.Spells)
            {
                spell.IncreaseSpeed(amount);
            }
        }
    }

    public void SetMaxFireBallsSpeed(float speed)
    {
        foreach (var fireBallEmitter in _fireBallEmitters)
        {
            foreach (var spell in fireBallEmitter.SpellRecycling.Spells)
            {
                spell.MaxSpeed = speed;
            }
        }
    }
}
