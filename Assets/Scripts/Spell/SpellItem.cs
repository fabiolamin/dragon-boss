using UnityEngine;

public class SpellItem : MonoBehaviour
{
    [SerializeField] private SpellInfo _spellInfo;
    public SpellInfo SpellInfo { get { return _spellInfo; } }
}
