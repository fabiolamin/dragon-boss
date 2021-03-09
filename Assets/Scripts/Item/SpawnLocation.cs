using UnityEngine;

public class SpawnLocation : MonoBehaviour
{
    private ParticleSystem _spawnVFX;
    [SerializeField] private ParticleSystem _spawnVFXPrefab;
    public bool HasItem { get; set; } = false;

    private void Awake()
    {
        _spawnVFX = Instantiate(_spawnVFXPrefab, transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity, transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlaySpawnVFX();
        HasItem = true;
        other.GetComponent<Item>().SpawnLocation = this;
    }

    public void PlaySpawnVFX()
    {
        _spawnVFX.Play();
    }
}
