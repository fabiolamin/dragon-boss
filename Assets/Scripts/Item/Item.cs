using UnityEngine;

public class Item : MonoBehaviour
{
    private ItemSpawner _itemSpawner;
    [SerializeField] private float _rotationSpeed = 10f;

    private void Awake()
    {
        _itemSpawner = transform.parent.GetComponent<ItemSpawner>();
        GetReadyToSpawn();
    }

    private void Update()
    {
        Rotate();
    }

    public void GetReadyToSpawn()
    {            
        _itemSpawner.StartSpawn();
        gameObject.SetActive(false);
    }

    private void Rotate()
    {
        transform.Rotate(0f, _rotationSpeed * Time.deltaTime, 0f);
    }

    public void MoveToLocation()
    {
        gameObject.SetActive(true);

        SpawnLocation spawnLocation = _itemSpawner.CurrentSpawnLocation;

        transform.position = new Vector3(spawnLocation.transform.position.x,
        transform.position.y,
       spawnLocation.transform.position.z);
    }

    public void SetSpawnLocation(SpawnLocation spawnLocation)
    {
        _itemSpawner.CurrentSpawnLocation = spawnLocation;
    }
}