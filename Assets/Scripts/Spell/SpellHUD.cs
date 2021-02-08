using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpellHUD : MonoBehaviour, IPointerDownHandler
{
    private PlayerAttack _playerAttack;
    [SerializeField] private SpellName _spellName;
    [SerializeField] private Text _spellAmountDisplay;
    [SerializeField] private GameObject _block;

    private void Awake()
    {
        _block.SetActive(true);
        PlayerPrefs.SetInt(_spellName.ToString(), 5);
        _playerAttack = FindObjectOfType<PlayerAttack>();
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        int amount = PlayerPrefs.GetInt(_spellName.ToString());
        _spellAmountDisplay.text = amount.ToString();
        _block.SetActive(amount == 0);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _playerAttack.SpellName = _spellName;
    }
}
