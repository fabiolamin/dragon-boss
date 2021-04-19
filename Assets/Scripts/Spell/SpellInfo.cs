using UnityEngine;

[CreateAssetMenu(fileName = "New Spell Info", menuName = "Spell Info")]
public class SpellInfo : ScriptableObject
{
    [SerializeField] private SpellName _spellName;
    [SerializeField] private float _damage = 1f;
    [SerializeField] private int _price = 20;

    public SpellName SpellName { get { return _spellName; } }
    public float Damage { get { return _damage; } }
    public int Price { get { return _price; } }
}
