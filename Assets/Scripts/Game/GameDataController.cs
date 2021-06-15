using UnityEngine;
using Newtonsoft.Json;
using System.Linq;
using System;

public class GameDataController : MonoBehaviour
{
    private static GameDataController _instance;
    private const string SAVE_NAME = "DRAGON_BOSS_";

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
    }

    public void SaveGameData()
    {
        string fileName = SAVE_NAME +
        DateTime.Now.Day +
        DateTime.Now.Month +
        DateTime.Now.Year +
        DateTime.Now.Hour +
        DateTime.Now.Minute +
        DateTime.Now.Second +
        DateTime.Now.Millisecond;

        _playGamesService.OpenSavedGame(true, fileName);
    }

    public void ShowSavedGames()
    {
        _playGamesService.ShowSelectUI();
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
