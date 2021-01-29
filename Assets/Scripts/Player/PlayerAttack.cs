using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private SpellRecycling _spellRecycling;

    public void CastSpell()
    {
        _spellRecycling.ActivateSpell();
    }
}
