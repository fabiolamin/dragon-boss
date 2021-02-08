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
        _playerAttack = FindObjectOfType<PlayerAttack>();
        UpdateDisplay();
        CheckSpellAmount(PlayerPrefs.GetInt(_spellName.ToString()));
    }

    public void UpdateDisplay()
    {
        int amount = PlayerPrefs.GetInt(_spellName.ToString());
        _spellAmountDisplay.text = amount.ToString();
        CheckSpellAmount(amount);
    }

    private void CheckSpellAmount(int amount)
    {
        if (amount <= 0)
        {
            _block.SetActive(true);
        }
        else
        {
            _block.SetActive(false);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _playerAttack.SpellName = _spellName;
    }
}
