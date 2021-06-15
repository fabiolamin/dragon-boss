using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] private SpellHUD[] _spellHUDs;
    [SerializeField] private DragonManager _dragonManager;
    [SerializeField] private Text playerCoinsDisplay;
    public int Coins { get; private set; }
    public GameObject PlayerCoinsDisplay { get { return playerCoinsDisplay.gameObject; } }

    private void Start()
    {
        Coins = GameDataController.Instance.GameData.Coins;
        UpdatePlayerCoinsDisplay();
    }

    private void UpdatePlayerCoinsDisplay()
    {
        playerCoinsDisplay.text = Coins.ToString();
    }

    public void Save()
    {
        int dragonsDefeated = _dragonManager.CurrentDragon - 1;

        if (dragonsDefeated > GameDataController.Instance.GameData.HighScore)
        {
            GameDataController.Instance.SaveHighScore(dragonsDefeated);
        }

        GameDataController.Instance.SaveGameData();
    }

    public void AddCoin()
    {
        Coins++;
        GameDataController.Instance.SaveCoins(Coins);
        UpdatePlayerCoinsDisplay();
    }

    public int GetAmountOfSpells(int spellId)
    {
        return GameDataController.Instance.GetSpellAmount(spellId);
    }

    public void UpdateAmountOfSpells(int spellId, int amount)
    {
        GameDataController.Instance.SaveSpellAmount(spellId, amount);
        _spellHUDs.ToList().ForEach(s => s.UpdateDisplay());
    }
}
