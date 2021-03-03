using UnityEngine;
public class PlayerAttack : MonoBehaviour
{
    private PlayerInfo _playerInfo;
    private Animator _animator;
    [SerializeField] private SpellRecycling _spellRecycling;

    public SpellName SpellName { get; set; }
    public bool CanAttack { get; set; } = true;

    private void Awake()
    {
        _playerInfo = GetComponent<PlayerInfo>();
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
