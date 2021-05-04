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

    private void Awake()
    {
        Coins = PlayerPrefs.GetInt("Coins");
        UpdatePlayerCoinsDisplay();
    }

    private void UpdatePlayerCoinsDisplay()
    {
        playerCoinsDisplay.text = Coins.ToString();
    }

    public void Save()
    {
        PlayerPrefs.SetInt("Coins", Coins);

        int wonArenas = _dragonManager.CurrentDragon - 1;
        if ((wonArenas) > PlayerPrefs.GetInt("HighScore"))
            PlayerPrefs.SetInt("HighScore", wonArenas);
    }

    public void AddCoin()
    {
        Coins++;
        UpdatePlayerCoinsDisplay();
    }

    public int GetAmountOfSpells(SpellName spellName)
    {
        return PlayerPrefs.GetInt(spellName.ToString());
    }

    public void UpdateAmountOfSpells(SpellName spellName, int value)
    {
        int amount = GetAmountOfSpells(spellName);
        amount += value;
        PlayerPrefs.SetInt(spellName.ToString(), amount);
        _spellHUDs.ToList().ForEach(s => s.UpdateDisplay());
    }
}
