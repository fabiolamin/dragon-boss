using System.Linq;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    [SerializeField] private GameObject[] _dragons;
    [SerializeField] private float _speedIncrementPerArena = 0.5f;
    [SerializeField] private float _maxFireBallSpeed = 20f;
    [SerializeField] private float _healthIncrementPerArena = 50f;

    public delegate void DragonDeath();
    public static event DragonDeath OnDragonDeath;

    private void Awake()
    {
        _dragons.ToList().ForEach(d => d.SetActive(false));
        ActiveDragon();
        OnDragonDeath += IncreaseDragonDifficulty;
    }

    public void ActiveDragon()
    {
        int random = Random.Range(0, _dragons.Length);
        _dragons[random].SetActive(true);
        _dragons[random].GetComponent<FireBallController>().SetMaxFireBallsSpeed(_maxFireBallSpeed);
    }

    private void IncreaseDragonDifficulty()
    {
        foreach (var dragon in _dragons)
        {
            dragon.GetComponent<FireBallController>().IncreaseFireBallsSpeed(_speedIncrementPerArena);
            dragon.GetComponent<DragonHealth>().IncreaseHealth(_healthIncrementPerArena);
        }
    }

    public static void SetDragonDeath()
    {
        OnDragonDeath.Invoke();
    }
}
