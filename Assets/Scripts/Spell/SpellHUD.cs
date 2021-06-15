using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpellHUD : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private PlayerAttack _playerAttack;
    [SerializeField] private SpellData _spellData;
    [SerializeField] private Text _spellAmountDisplay;
    [SerializeField] private GameObject _block;

    private void Start()
    {
        _block.SetActive(true);
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        int amount = GameDataController.Instance.GetSpellAmount(_spellData.Id);
        _spellAmountDisplay.text = amount.ToString();
        _block.SetActive(amount == 0);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SelectSpellToCast();
    }

    private void SelectSpellToCast()
    {
        _playerAttack.SpellId = _spellData.Id;
    }
}
