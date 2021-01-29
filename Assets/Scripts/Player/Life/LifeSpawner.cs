using System.Collections;
using UnityEngine;

public class LifeSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnLocations;
    [SerializeField] private Life _life;
    [SerializeField] private float _activationDelay = 4f;
    [SerializeField] private float _deactivationDelay = 3f;

    public void UpdateLifePosition()
    {
        int random = Random.Range(0, _spawnLocations.Length);

        _life.transform.position = new Vector3(_spawnLocations[random].position.x,
        _life.transform.position.y,
        _spawnLocations[random].position.z);

        StartCoroutine(SetActivation(false, _deactivationDelay));
    }

    public void SpawnLife()
    {
        StartCoroutine(SetActivation(true, _activationDelay));
    }

    public IEnumerator SetActivation(bool isActive, float delay)
    {
        yield return new WaitForSeconds(delay);
        _life.gameObject.SetActive(isActive);
    }
}
