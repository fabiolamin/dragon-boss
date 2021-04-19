using UnityEngine;
using UnityEngine.UI;

public class SpellPurchasing : MonoBehaviour
{
    [SerializeField] private SpellInfo _spellInfo;
    [SerializeField] private Text _nameDisplay;
    [SerializeField] private Text _damageDisplay;
    [SerializeField] private Text _priceDisplay;
    [SerializeField] private Text _spellAmountDisplay;
    [SerializeField] private Button _purchasingButton;
    [SerializeField] private Text _playerCoinsDisplay;

    private void Awake()
    {
        UpdatePlayerInfoDisplay();
        SetOrderDisplay();
        _purchasingButton.onClick.AddListener(PurchaseSpell);
    }

    private void UpdatePlayerInfoDisplay()
    {
        _playerCoinsDisplay.text = PlayerPrefs.GetInt("Coins").ToString();
        _spellAmountDisplay.text = PlayerPrefs.GetInt(_spellInfo.SpellName.ToString()).ToString();
    }

    private void SetOrderDisplay()
    {
        _nameDisplay.text = _spellInfo.SpellName.ToString();
        _damageDisplay.text = "Damage " + _spellInfo.Damage;
        _priceDisplay.text = _spellInfo.Price.ToString();
    }

    private void PurchaseSpell()
    {
        int playerCoins = PlayerPrefs.GetInt("Coins");

        if (playerCoins >= _spellInfo.Price)
        {
            AddSpell();
            UpdatePlayerCoins(playerCoins);
            UpdatePlayerInfoDisplay();
        }
    }

    private void AddSpell()
    {
        string spellName = _spellInfo.SpellName.ToString();
        int spellAmount = PlayerPrefs.GetInt(spellName);
        spellAmount++;
        PlayerPrefs.SetInt(spellName, spellAmount);
    }

    private void UpdatePlayerCoins(int playerCoins)
    {
        playerCoins -= _spellInfo.Price;
        PlayerPrefs.SetInt("Coins", playerCoins);
    }
}
