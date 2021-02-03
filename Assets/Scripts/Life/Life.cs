using UnityEngine;

public class Life : MonoBehaviour
{
    private LifeSpawner _lifeSpawner;

    private void Awake()
    {
        _lifeSpawner = FindObjectOfType<LifeSpawner>();
    }
    private void OnEnable()
    {
        _lifeSpawner.UpdateLifePosition();
    }

    private void OnDisable()
    {
        _lifeSpawner.SpawnLife();
    }
}
