using System.Collections;
using UnityEngine;
using System.Linq;

public class ItemSpawner : MonoBehaviour
{
    private Item _item;
    private SpawnLocation[] _spawnLocations;
    private Coroutine _spawnCoroutine;

    [SerializeField] private float _spawnInterval = 1f;
    [SerializeField] private float _minDelay = 3f;
    [SerializeField] private float _maxDelay = 4f;

    public SpawnLocation CurrentSpawnLocation { get; set; }

    private void Awake()
    {
        _item = transform.GetChild(0).GetComponent<Item>();
        _spawnLocations = FindObjectsOfType<SpawnLocation>();
    }

    public void StartSpawn()
    {
        StopSpawn();
        StartCoroutine(SetSpawnInterval());
    }

    public IEnumerator SetSpawnInterval()
    {
        yield return new WaitForSeconds(_spawnInterval);
        _spawnCoroutine = StartCoroutine(SpawnItem());
    }

    private IEnumerator SpawnItem()
    {
        CurrentSpawnLocation = GetAvailableSpawnLocation();
        _item.MoveToLocation();
        float delay = Random.Range(_minDelay, _maxDelay);
        yield return new WaitForSeconds(delay);
        CurrentSpawnLocation.PlaySpawnVFX();
        _item.GetReadyToSpawn();
    }

    private SpawnLocation GetAvailableSpawnLocation()
    {
        var availableSpawnLocations = _spawnLocations.Where(s => s.IsEmpty());
        int random = Random.Range(0, availableSpawnLocations.Count());
        return availableSpawnLocations.ElementAt(random);
    }

    public void StopSpawn()
    {
        if(_spawnCoroutine != null && CurrentSpawnLocation != null)
        {
            CurrentSpawnLocation.RemoveItem();
            CurrentSpawnLocation = null;
            StopCoroutine(_spawnCoroutine);
        }
    }
}