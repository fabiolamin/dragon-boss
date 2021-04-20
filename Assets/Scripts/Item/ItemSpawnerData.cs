using UnityEngine;

[CreateAssetMenu(fileName = "New Item Spawner Data", menuName = "Item Spawner Data")]
public class ItemSpawnerData : ScriptableObject
{
    [SerializeField] private float _spawnInterval;
    [SerializeField] private float _minDelay;
    [SerializeField] private float _maxDelay;

    public float SpawnInterval { get { return _spawnInterval; } }
    public float MinDelay { get { return _minDelay; } }
    public float MaxDelay { get { return _maxDelay; } }
}
