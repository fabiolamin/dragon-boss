using UnityEngine;

public class Spell : MonoBehaviour
{
    private Rigidbody _spellRb;
    [SerializeField] private float _speed = 10f;

    public Transform CastingOrigin { get; set; }

    private void Awake()
    {
        _spellRb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        if (CastingOrigin != null)
            _spellRb.velocity = CastingOrigin.forward * _speed;
    }
}
