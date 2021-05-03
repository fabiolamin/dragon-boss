using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpellHUD : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private PlayerAttack _playerAttack;
    [SerializeField] private SpellData _spellData;
    [SerializeField] private Text _spellAmountDisplay;
    [SerializeField] private GameObject _block;

    private void Awake()
    {
        _block.SetActive(true);
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        int amount = PlayerPrefs.GetInt(_spellData.SpellName.ToString());
        _spellAmountDisplay.text = amount.ToString();
        _block.SetActive(amount == 0);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SelectSpellToCast();
    }

    private void SelectSpellToCast()
    {
        _playerAttack.SpellName = _spellData.SpellName;
    }
}
