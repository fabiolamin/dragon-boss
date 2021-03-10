using UnityEngine;

public class Item : MonoBehaviour
{
    private ItemSpawner _itemSpawner;
    [SerializeField] private float _rotationSpeed = 10f;

    public SpawnLocation SpawnLocation { get; set; }

    private void Awake()
    {
        _itemSpawner = transform.parent.GetComponent<ItemSpawner>();
        gameObject.SetActive(false);
    }

    private void Update()
    {
        Rotate();
    }

    private void OnDisable()
    {
        if (SpawnLocation) { SpawnLocation.HasItem = false; }
        _itemSpawner.StartSpawn(this);
    }

    private void Rotate()
    {
        transform.Rotate(0f, _rotationSpeed * Time.deltaTime, 0f);
    }
}
