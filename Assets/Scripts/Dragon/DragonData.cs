using UnityEngine;

[CreateAssetMenu(fileName = "Dragon Data", menuName = "New Dragon Data")]
public class DragonData : ScriptableObject
{
    [SerializeField] private float _speedIncrementPerArena = 0.5f;
    [SerializeField] private float _healthIncrementPerArena = 50f;

    public float SpeedIncrementPerArena { get { return _speedIncrementPerArena; } }
    public float HealthIncrementPerArena { get { return _healthIncrementPerArena; } }
}
