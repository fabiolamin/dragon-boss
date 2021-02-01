using System.Collections;
using UnityEngine;

public class FireBallEmitter : MonoBehaviour
{
    [SerializeField] private SpellRecycling _spellRecycling;
    [SerializeField] private float _minDelay = 1f;
    [SerializeField] private float _maxDelay = 3f;

    public SpellRecycling SpellRecycling { get { return _spellRecycling; } }

    public IEnumerator DelayToEmit()
    {
        while (true)
        {
            float randomDelay = Random.Range(_minDelay, _maxDelay);
            yield return new WaitForSeconds(randomDelay);
            Emit();
        }
    }

    private void Emit()
    {
        _spellRecycling.ActivateSpell();
    }
}
