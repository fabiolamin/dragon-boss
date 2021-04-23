using UnityEngine;
using UnityEngine.UI;

public class DragonManager : MonoBehaviour
{
    [SerializeField] private DragonData _dragonData;
    [SerializeField] private Dragon[] _dragons;
    [SerializeField] private Text _currentDragonDisplay;

    public delegate void DragonDeathHandler();
    public event DragonDeathHandler DragonDeath;

    public int CurrentDragon { get; private set; } = 1;
    public GameObject CurrentDragonDisplay { get { return _currentDragonDisplay.gameObject; } }

    private void Start()
    {
        InitializeDragonsFireBall();
        SpawnRandomDragon();
        UpdateCurrentDragonDisplay();
        DragonDeath += NextDragon;
        DragonDeath += IncreaseDragonDifficulty;
        DragonDeath += SpawnRandomDragon;
    }

    private void InitializeDragonsFireBall()
    {
        foreach (Dragon dragon in _dragons)
        {
            dragon.InitializeFireBall();
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
        _dragons[random].Spawn();
    }

    private void IncreaseDragonDifficulty()
    {
        foreach (Dragon dragon in _dragons)
        {
            dragon.IncreaseDifficulty();
        }
    }

    public void OnDragonDeath()
    {
        DragonDeath?.Invoke();
    }
}
