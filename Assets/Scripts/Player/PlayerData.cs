using UnityEngine;

[CreateAssetMenu(fileName = "New Player Data", menuName = "Player Data")]
public class PlayerData : ScriptableObject
{
    [SerializeField] private float _speed;
    [SerializeField] private float _movementTime;
    [SerializeField] private float _delayFinishDamage;

    public float Speed { get { return _speed; } }
    public float MovementTime { get { return _movementTime; } }
    public float DelayFinishDamage { get { return _delayFinishDamage; } }
}
