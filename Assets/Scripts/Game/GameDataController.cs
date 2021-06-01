using UnityEngine;
using Newtonsoft.Json;
using System.Linq;

public class GameDataController : MonoBehaviour
{
    private static GameDataController _instance;
    [SerializeField] private PlayGamesService _playGamesService;

    public static GameDataController Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("Game Data Controller is NULL.");
            }

            return _instance;
        }
    }
    public GameData GameData { get; private set; }

    private void Awake()
    {
        _instance = this;

        if (string.IsNullOrEmpty(PlayerPrefs.GetString("GameData")))
        {
            GameData = new GameData();
            PlayerPrefs.SetString("GameData", JsonConvert.SerializeObject(GameData));
        }
        else
        {
            GameData = JsonConvert.DeserializeObject<GameData>(PlayerPrefs.GetString("GameData"));
        }

        Debug.Log(PlayerPrefs.GetString("GameData"));
    }

    public void SaveGameData()
    {
        _playGamesService.OpenSavedGame(true);
    }

    public void LoadGameData()
    {
        _playGamesService.OpenSavedGame(false);
    }

    public void SaveHighScore(int score)
    {
        GameData.HighScore = score;
        PlayerPrefs.SetString("GameData", JsonConvert.SerializeObject(GameData));
        _playGamesService.SaveHighScore(score);
    }

    public void SaveCoins(int coins)
    {
        GameData.Coins = coins;
        PlayerPrefs.SetString("GameData", JsonConvert.SerializeObject(GameData));
    }

    public void SaveHero(int id)
    {
        GameData.Hero = id;
        PlayerPrefs.SetString("GameData", JsonConvert.SerializeObject(GameData));
    }

    public void SaveHeroesData(string heroesData)
    {
        GameData.HeroesData = heroesData;
        PlayerPrefs.SetString("GameData", JsonConvert.SerializeObject(GameData));
    }

    public void SaveSpellAmount(int id, int amount)
    {
        SpellInfo spell = GameData.Spells.Single(s => s.Id == id);
        spell.Amount += amount;

        PlayerPrefs.SetString("GameData", JsonConvert.SerializeObject(GameData));
    }

    public int GetSpellAmount(int id)
    {
        return GameData.Spells.Single(s => s.Id == id).Amount;
    }
}
