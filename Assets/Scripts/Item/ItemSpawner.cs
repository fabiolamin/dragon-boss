using System.Collections;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnLocations;
    [SerializeField] private Item _item;
    [SerializeField] private float _minDelay = 4f;
    [SerializeField] private float _maxDelay = 3f;

    public void UpdateItemPosition()
    {
        int random = Random.Range(0, _spawnLocations.Length);

        _item.transform.position = new Vector3(_spawnLocations[random].position.x,
        _item.transform.position.y,
        _spawnLocations[random].position.z);

        StartCoroutine(SetActivation(false));
    }

    public void SpawnItem()
    {
        StartCoroutine(SetActivation(true));
    }

    public IEnumerator SetActivation(bool isActive)
    {
        float delay = Random.Range(_minDelay, _maxDelay);
        yield return new WaitForSeconds(delay);
        _item.gameObject.SetActive(isActive);
    }
}
