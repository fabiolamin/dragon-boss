using UnityEngine;
using System.Linq;

public class PlayerAttack : MonoBehaviour
{
    private SpellHUD[] _spellHUDs;
    private PlayerInfo _playerInfo;
    [SerializeField] private SpellRecycling _spellRecycling;

    public SpellName SpellName { get; set; }

    private void Awake()
    {
        _spellHUDs = FindObjectsOfType<SpellHUD>();
        _playerInfo = GetComponent<PlayerInfo>();
        _spellRecycling.InstantiateSpells();
        SpellName = SpellName.Default;
        DragonController.DragonDeathHandler += _spellRecycling.DeactivateSpells;
    }

    public void CastSpell()
    {
        if (Time.timeScale == 1)
        {
            if (_playerInfo.GetAmountOfSpells(SpellName) > 0)
            {
                _spellRecycling.ActivateSpell(SpellName);
                _playerInfo.UpdateAmountOfSpells(SpellName, -1);
                _spellHUDs.ToList().ForEach(s => s.UpdateDisplay());
            }
            else
            {
                _spellRecycling.ActivateSpell(SpellName.Default);
            }
        }
    }
}
