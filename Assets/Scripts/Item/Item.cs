using UnityEngine;

public class Item : MonoBehaviour
{
    private ItemSpawner _itemSpawner;

    private void Awake()
    {
        _itemSpawner = FindObjectOfType<ItemSpawner>();
    }
    private void OnEnable()
    {
        _itemSpawner.UpdateItemPosition();
    }

    private void OnDisable()
    {
        _itemSpawner.SpawnItem();
    }
}
