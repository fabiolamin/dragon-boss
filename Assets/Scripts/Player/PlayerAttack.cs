using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private SpellRecycling _spellRecycling;

    private void Awake()
    {
        _spellRecycling.InstantiateSpells();
    }

    public void CastSpell()
    {
        _spellRecycling.ActivateSpell();
    }
}
