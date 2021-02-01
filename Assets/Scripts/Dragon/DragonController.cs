using System.Linq;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    [SerializeField] private GameObject[] _dragons;
    [SerializeField] private float _speedIncrementPerArena = 0.5f;
    [SerializeField] private float _maxFireBallSpeed = 20f;
    [SerializeField] private float _healthIncrementPerArena = 50f;

    public delegate void DragonDeath();
    public static event DragonDeath DragonDeathHandler;

    private void Awake()
    {
        SetDragons();
        ActiveRandomDragon();
        DragonDeathHandler += IncreaseDragonDifficulty;
    }

    private void SetDragons()
    {
        foreach (var dragon in _dragons)
        {
            FireBallController fireBallController = dragon.GetComponent<FireBallController>();
            fireBallController.SetFireBalls();
            fireBallController.SetMaxFireBallsSpeed(_maxFireBallSpeed);
            dragon.SetActive(false);
        }
    }

    public void ActiveRandomDragon()
    {
        int random = Random.Range(0, _dragons.Length);
        _dragons[random].SetActive(true);
        _dragons[random].GetComponent<FireBallController>().EmitFireBalls();
    }

    private void IncreaseDragonDifficulty()
    {
        foreach (var dragon in _dragons)
        {
            dragon.GetComponent<FireBallController>().IncreaseFireBallsSpeed(_speedIncrementPerArena);
            dragon.GetComponent<DragonHealth>().IncreaseHealth(_healthIncrementPerArena);
        }

        ActiveRandomDragon();
    }

    public static void OnDragonDeath()
    {
        DragonDeathHandler.Invoke();
    }
}
