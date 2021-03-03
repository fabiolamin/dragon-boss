using UnityEngine;

public class SpawnLocation : MonoBehaviour
{
    public bool HasItem { get; set; } = false;

    private void OnTriggerEnter(Collider other)
    {
        HasItem = true;
        other.GetComponent<Item>().SpawnLocation = this;
    }
}
