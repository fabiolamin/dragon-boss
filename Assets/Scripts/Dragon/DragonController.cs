using UnityEngine;
using UnityEngine.UI;

public class DragonController : MonoBehaviour
{
    [SerializeField] private GameObject[] _dragons;
    [SerializeField] private Text _currentDragonDisplay;
    [SerializeField] private float _speedIncrementPerArena = 0.5f;
    [SerializeField] private float _healthIncrementPerArena = 50f;

    public delegate void DragonDeath();
    public static event DragonDeath DragonDeathHandler;

    public int CurrentDragon { get; private set; } = 1;
    public GameObject CurrentDragonDisplay { get { return _currentDragonDisplay.gameObject; } }

    private void Awake()
    {
        SetDragons();
        SpawnRandomDragon();
        UpdateCurrentDragonDisplay();
        DragonDeathHandler += NextDragon;
        DragonDeathHandler += IncreaseDragonDifficulty;
        DragonDeathHandler += SpawnRandomDragon;
    }

    private void OnDestroy()
    {
        if (DragonDeathHandler != null)
        {
            foreach (var item in DragonDeathHandler.GetInvocationList())
            {
                DragonDeathHandler -= (DragonDeath)item;
            }
        }
    }

    private void SetDragons()
    {
        foreach (var dragon in _dragons)
        {
            FireBallController fireBallController = dragon.GetComponent<FireBallController>();
            fireBallController.SetFireBalls();
            dragon.SetActive(false);
        }
    }

    private void UpdateCurrentDragonDisplay()
    {
        _currentDragonDisplay.text = "Dragon " + CurrentDragon.ToString();
    }

    public void NextDragon()
    {
        CurrentDragon++;
        UpdateCurrentDragonDisplay();
    }

    public void SpawnRandomDragon()
    {
        int random = Random.Range(0, _dragons.Length);
        _dragons[random].GetComponent<DragonSpawner>().Spawn();
    }

    private void IncreaseDragonDifficulty()
    {
        foreach (var dragon in _dragons)
        {
            dragon.GetComponent<FireBallController>().IncreaseFireBallsSpeed(_speedIncrementPerArena);
            dragon.GetComponent<DragonHealth>().IncreaseHealth(_healthIncrementPerArena);
        }
    }

    public static void OnDragonDeath()
    {
        DragonDeathHandler.Invoke();
    }
}
