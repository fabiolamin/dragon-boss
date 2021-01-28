using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Spell _spell;
    [SerializeField] private Transform casting;

    public void CastSpell()
    {
        Instantiate(_spell, casting.position, Quaternion.identity);
    }
}
