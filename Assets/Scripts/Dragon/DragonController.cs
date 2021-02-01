using UnityEngine;

public class DragonController : MonoBehaviour
{
    [SerializeField] private GameObject[] _dragons;
    [SerializeField] private float _speedIncrementPerArena = 0.5f;
    [SerializeField] private float _maxFireBallSpeed = 20f;
    [SerializeField] private float _healthIncrementPerArena = 50f;

    private void Awake()
    {
        ActiveDragon();
    }

    private void ActiveDragon()
    {
        int random = Random.Range(0, _dragons.Length);
        _dragons[random].SetActive(true);
    }

    private void IncreaseDragonDifficulty()
    {
        foreach (var dragon in _dragons)
        {
            // Increase Spell speed
            dragon.GetComponent<DragonHealth>().IncreaseHealth(_healthIncrementPerArena);
        }
    }
}
