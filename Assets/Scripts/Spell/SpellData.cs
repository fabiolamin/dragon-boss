using UnityEngine;

[CreateAssetMenu(fileName = "New Spell Data", menuName = "Spell Data")]
public class SpellData : ScriptableObject
{
    [SerializeField] private SpellName _spellName;
    [SerializeField] private float _damage = 1f;
    [SerializeField] private int _price = 20;

    public SpellName SpellName { get { return _spellName; } }
    public float Damage { get { return _damage; } }
    public int Price { get { return _price; } }
}
