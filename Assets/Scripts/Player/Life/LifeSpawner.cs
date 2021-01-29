using System.Collections;
using UnityEngine;

public class LifeSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnLocations;
    [SerializeField] private Life _life;
    [SerializeField] private float _minDelay = 4f;
    [SerializeField] private float _maxDelay = 3f;

    public void UpdateLifePosition()
    {
        int random = Random.Range(0, _spawnLocations.Length);

        _life.transform.position = new Vector3(_spawnLocations[random].position.x,
        _life.transform.position.y,
        _spawnLocations[random].position.z);

        StartCoroutine(SetActivation(false));
    }

    public void SpawnLife()
    {
        StartCoroutine(SetActivation(true));
    }

    public IEnumerator SetActivation(bool isActive)
    {
        float delay = Random.Range(_minDelay, _maxDelay);
        yield return new WaitForSeconds(delay);
        _life.gameObject.SetActive(isActive);
    }
}
