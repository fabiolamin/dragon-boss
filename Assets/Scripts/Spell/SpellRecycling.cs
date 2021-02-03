using UnityEngine;

public class SpellRecycling : MonoBehaviour
{
    [SerializeField] private Spell _spell;
    [SerializeField] private int _amount = 10;
    [SerializeField] private Transform _spellsParent;

    public Spell[] Spells { get; private set; }

    public void InstantiateSpells()
    {
        Spells = new Spell[_amount];

        for (int x = 0; x < _amount; x++)
        {
            Spell spell = Instantiate(_spell, transform.position, Quaternion.identity);
            spell.transform.parent = _spellsParent;
            spell.CastingOrigin = transform;
            spell.gameObject.SetActive(false);
            Spells[x] = spell;
        }
    }

    public void ActivateSpell()
    {
        foreach (var spell in Spells)
        {
            if (!spell.gameObject.activeSelf)
            {
                spell.gameObject.SetActive(true);
                spell.transform.position = transform.position;
                break;
            }
        }
    }

    public void DeactivateSpells()
    {
        foreach (var spell in Spells)
        {
            spell.gameObject.SetActive(false);
        }
    }
}
