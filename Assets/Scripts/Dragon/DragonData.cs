using UnityEngine;

[CreateAssetMenu(fileName = "New Dragon Data", menuName = "Dragon Data")]
public class DragonData : ScriptableObject
{
    [SerializeField] private float _speedIncrementPerArena = 0.5f;
    [SerializeField] private float _healthIncrementPerArena = 50f;

    public float SpeedIncrementPerArena { get { return _speedIncrementPerArena; } }
    public float HealthIncrementPerArena { get { return _healthIncrementPerArena; } }
}
