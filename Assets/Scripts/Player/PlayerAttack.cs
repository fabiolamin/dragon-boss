using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Spell _spell;
    [SerializeField] private Transform _casting;

    public void CastSpell()
    {
        Instantiate(_spell, _casting.position, Quaternion.identity);
    }
}
