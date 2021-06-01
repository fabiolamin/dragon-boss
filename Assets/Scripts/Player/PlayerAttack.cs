using UnityEngine;
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private PlayerInfo _playerInfo;
    [SerializeField] private HeroController _heroController;
    [SerializeField] private DragonManager _dragonManager;
    [SerializeField] private SpellRecycling _spellRecycling;
    [SerializeField] private SpellData _defaultSpellData;

    public int SpellId { get; set; }
    public bool CanAttack { get; set; } = true;

    private void Start()
    {
        _spellRecycling.InstantiateSpells();
        SpellId = _defaultSpellData.Id;
        _dragonManager.DragonDeath += _spellRecycling.DeactivateSpells;
    }

    public void CastSpell()
    {
        if (CanCastSpell())
        {
            transform.forward = new Vector3(0f, 0f, 1f);
            _heroController.HeroAnimator.SetTrigger("Attack");

            if (_playerInfo.GetAmountOfSpells(SpellId) > 0)
            {
                _spellRecycling.ActivateSpell(SpellId);
                _playerInfo.UpdateAmountOfSpells(SpellId, -1);
            }
            else
            {
                _spellRecycling.ActivateSpell(_defaultSpellData.Id);
            }

            SpellId = _defaultSpellData.Id;
        }
    }

    private bool CanCastSpell()
    {
        return Time.timeScale == 1 && CanAttack;
    }
}