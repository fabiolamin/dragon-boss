using System.Collections.Generic;
using UnityEngine;

public class SpellRecycling : MonoBehaviour
{
    [SerializeField] private Spell[] _spells;
    [SerializeField] private int _amount = 10;
    [SerializeField] private Transform _spellsParent;

    public List<Spell> SpellsInstantiated { get; private set; } = new List<Spell>();

    public void InstantiateSpells()
    {
        for (int y = 0; y < _spells.Length; y++)
        {
            for (int x = 0; x < _amount; x++)
            {
                Spell spell = Instantiate(_spells[y], transform.position, Quaternion.identity);
                spell.transform.parent = _spellsParent;
                spell.CastingOrigin = transform;
                spell.gameObject.SetActive(false);
                SpellsInstantiated.Add(spell);
            }
        }
    }

    public void ActivateSpell(int id)
    {
        foreach (var spell in SpellsInstantiated)
        {
            if (!spell.gameObject.activeSelf && spell.SpellData.Id == id)
            {
                spell.gameObject.SetActive(true);
                spell.transform.position = transform.position;
                break;
            }
        }
    }

    public void DeactivateSpells()
    {
        foreach (var spell in SpellsInstantiated)
        {
            spell.gameObject.SetActive(false);
        }
    }
}
