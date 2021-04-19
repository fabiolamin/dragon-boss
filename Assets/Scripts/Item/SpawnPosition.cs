using UnityEngine;

public class SpawnPosition : MonoBehaviour
{
    private ParticleSystem _spawnVFX;

    [SerializeField] private ParticleSystem _spawnVFXPrefab;

    public bool IsEmpty { get; set; } = true;

    private void Awake()
    {
        _spawnVFX = Instantiate(_spawnVFXPrefab, transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity, transform);
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void PlaySpawnVFX()
    {
        _spawnVFX.Play();
    }
}