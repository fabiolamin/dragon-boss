using UnityEngine;

public class Spell : MonoBehaviour
{
    private Rigidbody _spellRb;
    private float _currentSpeed;

    [SerializeField] private SpellData _spellData;

    public SpellData SpellData { get { return _spellData; } }
    public Transform CastingOrigin { get; set; }

    private void Awake()
    {
        _spellRb = GetComponent<Rigidbody>();
        _currentSpeed = _spellData.Speed;
    }

    private void OnEnable()
    {
        if (CastingOrigin != null)
            _spellRb.velocity = CastingOrigin.forward * _currentSpeed;
    }

    public void IncreaseSpeed(float amount)
    {
        _currentSpeed = Mathf.Clamp(_currentSpeed + amount, 0, _spellData.MaxSpeed);
    }
}
