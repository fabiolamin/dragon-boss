using System.Collections;
using UnityEngine;
using System.Linq;

public class ItemSpawner : MonoBehaviour
{
    private Item _item;
    private SpawnPosition[] _spawnPositions;
    private Coroutine _spawnCoroutine;

    [SerializeField] private ItemSpawnerData _itemSpawnerData;

    public SpawnPosition CurrentSpawnPosition { get; set; }

    private void Awake()
    {
        _item = transform.GetChild(0).GetComponent<Item>();
        _spawnPositions = FindObjectsOfType<SpawnPosition>();

        StartSpawn();
    }

    public void StartSpawn()
    {
        _item.gameObject.SetActive(false);
        ResetSpawn();
        StartCoroutine(SetSpawnInterval());
    }

    private void ResetSpawn()
    {
        if (_spawnCoroutine != null && CurrentSpawnPosition != null)
        {
            CurrentSpawnPosition.IsEmpty = true;
            StopCoroutine(_spawnCoroutine);
        }
    }

    public IEnumerator SetSpawnInterval()
    {
        yield return new WaitForSeconds(_itemSpawnerData.SpawnInterval);
        _spawnCoroutine = StartCoroutine(SpawnItem());
    }

    private IEnumerator SpawnItem()
    {
        SetItemSpawnPosition();
        float delay = Random.Range(_itemSpawnerData.MinDelay, _itemSpawnerData.MaxDelay);
        yield return new WaitForSeconds(delay);
        CurrentSpawnPosition.PlaySpawnVFX();
        StartSpawn();
    }

    private void SetItemSpawnPosition()
    {
        CurrentSpawnPosition = GetAvailableSpawnPosition();
        CurrentSpawnPosition.PlaySpawnVFX();
        CurrentSpawnPosition.IsEmpty = false;
        _item.SetNewPosition(CurrentSpawnPosition.GetPosition());
    }

    private SpawnPosition GetAvailableSpawnPosition()
    {
        var availableSpawnLocations = _spawnPositions.Where(s => s.IsEmpty);
        int random = Random.Range(0, availableSpawnLocations.Count());
        return availableSpawnLocations.ElementAt(random);
    }
}