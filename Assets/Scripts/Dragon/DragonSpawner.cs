using UnityEngine;

public class DragonSpawner : MonoBehaviour
{
    private FireBallController _fireBallController;
    [SerializeField] private ParticleSystem _spawnVFX;

    private void Awake()
    {
        _fireBallController = GetComponent<FireBallController>();
    }

    public void Spawn()
    {
        gameObject.SetActive(true);
        _spawnVFX.Play();
        _fireBallController.EmitFireBalls();
    }
}
