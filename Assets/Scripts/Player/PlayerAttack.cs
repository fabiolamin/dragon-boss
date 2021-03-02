using UnityEngine;
using System.Linq;

public class PlayerAttack : MonoBehaviour
{
    private SpellHUD[] _spellHUDs;
    private PlayerInfo _playerInfo;
    private PlayerHealth _playerHealth;
    private Animator _animator;
    [SerializeField] private SpellRecycling _spellRecycling;

    public SpellName SpellName { get; set; }
    public bool CanAttack { get; set; } = true;

    private void Awake()
    {
        _spellHUDs = FindObjectsOfType<SpellHUD>();
        _playerInfo = GetComponent<PlayerInfo>();
        _playerHealth = GetComponent<PlayerHealth>();
        _animator = GetComponent<Animator>();
        _spellRecycling.InstantiateSpells();
        SpellName = SpellName.Default;
        DragonController.DragonDeathHandler += _spellRecycling.DeactivateSpells;
    }

    public void CastSpell()
    {
        if (CanCastSpell())
        {
            transform.forward = new Vector3(0f, 0f, 1f);
            _animator.SetTrigger("Attack");

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

    private bool CanCastSpell()
    {
        return Time.timeScale == 1 && CanAttack;
    }
}
