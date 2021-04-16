using UnityEngine;

public class SpawnLocation : MonoBehaviour
{
    private bool _hasItem = false;
    private ParticleSystem _spawnVFX;
    [SerializeField] private ParticleSystem _spawnVFXPrefab;

    private void Awake()
    {
        _spawnVFX = Instantiate(_spawnVFXPrefab, transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity, transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlaySpawnVFX();
        _hasItem = true;
        other.GetComponent<Item>().SetSpawnLocation(this);
    }

    public void RemoveItem()
    {
        if (_hasItem)
        {
            _hasItem = false;
        }
    }

    public void PlaySpawnVFX()
    {
        _spawnVFX.Play();
    }

    public bool IsEmpty()
    {
        return !_hasItem;
    }
}
