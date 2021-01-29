using UnityEngine;

public class Spell : MonoBehaviour
{
    private Rigidbody _spellRb;
    [SerializeField] private float _speed = 10f;

    private void Awake()
    {
        _spellRb = GetComponent<Rigidbody>();
        _spellRb.velocity = transform.parent.forward * _speed;
    }
}
