using UnityEngine;

public class SpellRecycling : MonoBehaviour
{
    private Spell[] _spells;
    [SerializeField] private Spell _spell;
    [SerializeField] private int _amount = 10;
    [SerializeField] private Transform _spellsParent;

    private void Awake()
    {
        _spells = new Spell[_amount];
        InstantiateSpells();
    }

    private void InstantiateSpells()
    {
        for (int x = 0; x < _amount; x++)
        {
            Spell spell = Instantiate(_spell, transform.position, Quaternion.identity);
            spell.transform.parent = _spellsParent;
            spell.CastingOrigin = transform;
            spell.gameObject.SetActive(false);
            _spells[x] = spell;
        }
    }

    public void ActivateSpell()
    {
        foreach (var spell in _spells)
        {
            if (!spell.gameObject.activeSelf)
            {
                spell.gameObject.SetActive(true);
                spell.transform.position = transform.position;
                break;
            }
        }
    }
}
