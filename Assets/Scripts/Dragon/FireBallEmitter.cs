using System.Collections;
using UnityEngine;

public class FireBallEmitter : MonoBehaviour
{
    [SerializeField] private FireBallEmitterData _fireBallEmitterData;
    [SerializeField] private SpellRecycling _spellRecycling;

    public SpellRecycling SpellRecycling { get { return _spellRecycling; } }

    public IEnumerator DelayToEmit()
    {
        while (true)
        {
            float randomDelay = Random.Range(_fireBallEmitterData.MinDelay, _fireBallEmitterData.MaxDelay);
            yield return new WaitForSeconds(randomDelay);
            Emit();
        }
    }

    private void Emit()
    {
        _spellRecycling.ActivateSpell(SpellName.Default);
    }
}
