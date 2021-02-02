using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private SpellRecycling _spellRecycling;

    private void Awake()
    {
        _spellRecycling.InstantiateSpells();
        DragonController.DragonDeathHandler += _spellRecycling.DeactivateSpells;
    }

    public void CastSpell()
    {
        if (Time.timeScale == 1)
            _spellRecycling.ActivateSpell();
    }
}
