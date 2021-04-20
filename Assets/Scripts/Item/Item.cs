using UnityEngine;

public abstract class Item : MonoBehaviour
{
    private ItemSpawner _itemSpawner;
    [SerializeField] private float _rotationSpeed = 10f;


    private void Awake()
    {
        _itemSpawner = transform.parent.GetComponent<ItemSpawner>();
    }

    private void Update()
    {
        Rotate();
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();

        if (player != null)
        {
            PickUpItem(player);
        }
    }

    private void PickUpItem(Player player)
    {
        player.PlayBonusEffects();
        SetBonus(player);
        _itemSpawner.StartSpawn();
    }

    private void Rotate()
    {
        transform.Rotate(0f, _rotationSpeed * Time.deltaTime, 0f);
    }

    public void SetNewPosition(Vector3 position)
    {
        gameObject.SetActive(true);

        Vector3 newPosition = new Vector3(position.x, transform.position.y, position.z);
        transform.position = newPosition;
    }

    protected abstract void SetBonus(Player player);
}