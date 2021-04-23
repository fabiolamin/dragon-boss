using UnityEngine;
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private PlayerInfo _playerInfo;
    [SerializeField] private HeroController _heroController;
    [SerializeField] private DragonManager _dragonManager;
    [SerializeField] private SpellRecycling _spellRecycling;

    public SpellName SpellName { get; set; }
    public bool CanAttack { get; set; } = true;

    private void Start()
    {
        _spellRecycling.InstantiateSpells();
        SpellName = SpellName.Default;
        _dragonManager.DragonDeath += _spellRecycling.DeactivateSpells;
    }

    public void CastSpell()
    {
        if (CanCastSpell())
        {
            transform.forward = new Vector3(0f, 0f, 1f);
            _heroController.HeroAnimator.SetTrigger("Attack");

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