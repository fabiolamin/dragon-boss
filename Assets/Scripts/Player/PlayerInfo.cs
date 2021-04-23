using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PlayerInfo : MonoBehaviour
{
    private SpellHUD[] _spellHUDs;
    private DragonManager _dragonController;

    [SerializeField] private Text playerCoinsDisplay;
    public int Coins { get; private set; }
    public GameObject PlayerCoinsDisplay { get { return playerCoinsDisplay.gameObject; } }

    private void Awake()
    {
        _spellHUDs = FindObjectsOfType<SpellHUD>();
        _dragonController = FindObjectOfType<DragonManager>();
        Coins = PlayerPrefs.GetInt("Coins");
        UpdatePlayerCoinsDisplay();
    }

    private void UpdatePlayerCoinsDisplay()
    {
        playerCoinsDisplay.text = Coins.ToString();
    }

    public void SaveCoins()
    {
        Coins++;
        PlayerPrefs.SetInt("Coins", Coins);
        UpdatePlayerCoinsDisplay();
    }

    public void SaveHighScore()
    {
        int wonArenas = _dragonController.CurrentDragon - 1;

        if ((wonArenas) > PlayerPrefs.GetInt("HighScore"))
            PlayerPrefs.SetInt("HighScore", wonArenas);
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
