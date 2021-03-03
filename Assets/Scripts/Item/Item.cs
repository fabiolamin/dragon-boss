using UnityEngine;

public class Item : MonoBehaviour
{
    private ItemSpawner _itemSpawner;

    public SpawnLocation SpawnLocation { get; set; }

    private void Awake()
    {
        _itemSpawner = transform.parent.GetComponent<ItemSpawner>();
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        if (SpawnLocation) { SpawnLocation.HasItem = false; }
        _itemSpawner.StartSpawn(this);
    }
}
