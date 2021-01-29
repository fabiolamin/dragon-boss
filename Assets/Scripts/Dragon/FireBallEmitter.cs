using System.Collections;
using UnityEngine;

public class FireBallEmitter : MonoBehaviour
{
    [SerializeField] private SpellRecycling _spellRecycling;
    [SerializeField] private float minDelay = 1f;
    [SerializeField] private float maxDelay = 3f;

    private void Awake()
    {
        StartCoroutine(DelayToEmit());
    }

    private IEnumerator DelayToEmit()
    {
        while (true)
        {
            float randomDelay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(randomDelay);
            Emit();
        }
    }

    private void Emit()
    {
        _spellRecycling.ActivateSpell();
    }
}
