using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemSpawner _itemSpawner;

    private void OnEnable()
    {
        _itemSpawner.UpdateItemPosition();
    }

    private void OnDisable()
    {
        _itemSpawner.SpawnItem();
    }
}
