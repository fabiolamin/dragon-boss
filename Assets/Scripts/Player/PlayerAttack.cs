using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Spell _spell;

    public void CastSpell()
    {
        Instantiate(_spell, transform.position, Quaternion.identity);
    }
}
