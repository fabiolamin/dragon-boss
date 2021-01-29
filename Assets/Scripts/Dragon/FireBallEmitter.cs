using System.Collections;
using UnityEngine;

public class FireBallEmitter : MonoBehaviour
{
    [SerializeField] private Spell _fireBall;
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
        Instantiate(_fireBall, transform.position, Quaternion.identity, transform);
    }
}
