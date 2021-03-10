using System.Collections;
using UnityEngine;
using System.Linq;

public class ItemSpawner : MonoBehaviour
{
    private SpawnLocation[] _spawnLocations;

    [SerializeField] private float _spawnInterval = 1f;
    [SerializeField] private float _minDelay = 4f;
    [SerializeField] private float _maxDelay = 3f;

    private void Awake()
    {
        _spawnLocations = FindObjectsOfType<SpawnLocation>();
    }

    public void StartSpawn(Item item)
    {
        StartCoroutine(SetSpawnInterval(item));
    }

    public IEnumerator SetSpawnInterval(Item item)
    {
        yield return new WaitForSeconds(_spawnInterval);
        StartCoroutine(SpawnItem(item));
    }

    private IEnumerator SpawnItem(Item item)
    {
        item.gameObject.SetActive(true);
        SetItemPosition(item);
        float delay = Random.Range(_minDelay, _maxDelay);
        yield return new WaitForSeconds(delay);
        item.SpawnLocation.PlaySpawnVFX();
        item.gameObject.SetActive(false);
    }

    private void SetItemPosition(Item item)
    {
        SpawnLocation spawnLocation = GetAvailableSpawnLocation();

        item.transform.position = new Vector3(spawnLocation.transform.position.x,
        item.transform.position.y,
       spawnLocation.transform.position.z);
    }

    private SpawnLocation GetAvailableSpawnLocation()
    {
        var availableSpawnLocations = _spawnLocations.Where(s => !s.HasItem);
        int random = Random.Range(0, availableSpawnLocations.Count());
        return availableSpawnLocations.ElementAt(random);
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
