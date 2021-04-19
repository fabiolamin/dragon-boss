using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 10f;

    public ItemSpawner ItemSpawner { get; private set; }

    private void Awake()
    {
        ItemSpawner = transform.parent.GetComponent<ItemSpawner>();
    }

    private void Update()
    {
        Rotate();
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
}