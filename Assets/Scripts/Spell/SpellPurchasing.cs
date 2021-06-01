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

    private void Start()
    {
        UpdatePlayerInfoDisplay();
        SetOrderDisplay();
        _purchasingButton.onClick.AddListener(PurchaseSpell);
    }

    private void UpdatePlayerInfoDisplay()
    {
        _playerCoinsDisplay.text = GameDataController.Instance.GameData.Coins.ToString();
        _spellAmountDisplay.text = GameDataController.Instance.GetSpellAmount(_spellData.Id).ToString();
    }

    private void SetOrderDisplay()
    {
        _nameDisplay.text = _spellData.SpellName.ToString();
        _damageDisplay.text = "Damage " + _spellData.Damage;
        _priceDisplay.text = _spellData.Price.ToString();
    }

    private void PurchaseSpell()
    {
        int playerCoins = GameDataController.Instance.GameData.Coins;

        if (playerCoins >= _spellData.Price)
        {
            GameDataController.Instance.SaveSpellAmount(_spellData.Id, 1);
            GameDataController.Instance.SaveCoins(playerCoins - _spellData.Price);
            UpdatePlayerInfoDisplay();
        }
    }
}
