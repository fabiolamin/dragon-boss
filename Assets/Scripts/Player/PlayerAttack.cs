using UnityEngine;
public class PlayerAttack : MonoBehaviour
{
    private PlayerInfo _playerInfo;
    private HeroController _heroController;

    [SerializeField] private SpellRecycling _spellRecycling;
    [SerializeField] private AudioClip _spellClip;
    [SerializeField] protected SoundPlayer _soundPlayer;

    public SpellName SpellName { get; set; }
    public bool CanAttack { get; set; } = true;

    private void Start()
    {
        _playerInfo = GetComponent<PlayerInfo>();
        _heroController = GetComponent<HeroController>();
        _spellRecycling.InstantiateSpells();
        SpellName = SpellName.Default;
        DragonController.DragonDeathHandler += _spellRecycling.DeactivateSpells;
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
