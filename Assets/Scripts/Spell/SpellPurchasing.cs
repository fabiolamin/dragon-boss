using UnityEngine;
using UnityEngine.UI;

public class SpellPurchasing : MonoBehaviour
{
    [SerializeField] private SpellData _spellData;
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
        _spellAmountDisplay.text = PlayerPrefs.GetInt(_spellData.SpellName.ToString()).ToString();
    }

    private void SetOrderDisplay()
    {
        _nameDisplay.text = _spellData.SpellName.ToString();
        _damageDisplay.text = "Damage " + _spellData.Damage;
        _priceDisplay.text = _spellData.Price.ToString();
    }

    private void PurchaseSpell()
    {
        int playerCoins = PlayerPrefs.GetInt("Coins");

        if (playerCoins >= _spellData.Price)
        {
            AddSpell();
            UpdatePlayerCoins(playerCoins);
            UpdatePlayerInfoDisplay();
        }
    }

    private void AddSpell()
    {
        string spellName = _spellData.SpellName.ToString();
        int spellAmount = PlayerPrefs.GetInt(spellName);
        spellAmount++;
        PlayerPrefs.SetInt(spellName, spellAmount);
    }

    private void UpdatePlayerCoins(int playerCoins)
    {
        playerCoins -= _spellData.Price;
        PlayerPrefs.SetInt("Coins", playerCoins);
    }
}
