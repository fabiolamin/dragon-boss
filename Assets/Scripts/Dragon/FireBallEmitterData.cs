using UnityEngine;

[CreateAssetMenu(fileName = "New Fire Ball Emitter Data", menuName = "Fire Ball Emitter Data")]
public class FireBallEmitterData : ScriptableObject
{
    [SerializeField] private float _minDelay;
    [SerializeField] private float _maxDelay;

    public float MinDelay { get { return _minDelay; } }
    public float MaxDelay { get { return _maxDelay; } }
}
