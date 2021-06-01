using UnityEngine;

[CreateAssetMenu(fileName = "Spell Data", menuName = "New Spell Data")]
public class SpellData : ScriptableObject
{
    [SerializeField] private int _id;
    [SerializeField] private SpellName _spellName;
    [SerializeField] private float _damage = 1f;
    [SerializeField] private int _price = 20;
    [SerializeField] private float _speed;
    [SerializeField] private float _maxSpeed;

    public int Id { get { return _id; } }
    public SpellName SpellName { get { return _spellName; } }
    public float Damage { get { return _damage; } }
    public int Price { get { return _price; } }
    public float Speed { get { return _speed; } }
    public float MaxSpeed { get { return _maxSpeed; } }
}
