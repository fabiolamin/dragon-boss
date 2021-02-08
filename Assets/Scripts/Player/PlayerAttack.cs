using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerInfo _playerInfo;
    [SerializeField] private SpellRecycling _spellRecycling;

    public SpellName SpellName { get; set; }

    private void Awake()
    {
        _playerInfo = GetComponent<PlayerInfo>();
        _spellRecycling.InstantiateSpells();
        SpellName = SpellName.Default;
        DragonController.DragonDeathHandler += _spellRecycling.DeactivateSpells;
    }

    public void CastSpell()
    {
        if (Time.timeScale == 1)
            ActivateSpell(SpellName);
    }

    private void ActivateSpell(SpellName spellName)
    {
        if (_playerInfo.GetAmountOfSpells(spellName) > 0)
            _spellRecycling.ActivateSpell(spellName);
        else
            _spellRecycling.ActivateSpell(SpellName.Default);
    }
}
