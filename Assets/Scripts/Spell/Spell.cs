using UnityEngine;

public class Spell : MonoBehaviour
{
    private Rigidbody _spellRb;
    [SerializeField] private float _speed = 10f;

    public float Speed { get { return _speed; } set { _speed = value; } }
    public float MaxSpeed { get; set; }

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

    public void IncreaseSpeed(float amount)
    {
        _speed = Mathf.Clamp(_speed + amount, 0, MaxSpeed);
    }
}
