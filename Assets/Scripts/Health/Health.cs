using UnityEngine;
using System.Collections;

public abstract class Health : MonoBehaviour
{
    protected Animator animator;
    [SerializeField] protected float _currentHealth;
    [SerializeField] protected float health = 3f;
    [SerializeField] protected float _delayDeathTrigger = 0.5f;
    [SerializeField] protected ParticleSystem damageVFX;
    public bool IsAlive { get; private set; } = true;

    private void Awake()
    {
        _currentHealth = health;
        UpdateHealthDisplay();
    }

    public void GetDamage(Collider other)
    {
        if (IsAlive)
        {
            damageVFX.Play();
            SetDamageAnimation();
            Spell spell = other.gameObject.GetComponent<Spell>();
            UpdateCurrentHealth(-spell.SpellInfo.Damage);
        }
    }

    public void UpdateCurrentHealth(float amount)
    {
        if (!SceneLoader.IsLoading && IsAlive)
        {
            _currentHealth = Mathf.Clamp(_currentHealth + amount, 0, health);
            UpdateHealthDisplay();
            CheckHealth();
        }
    }

    private void CheckHealth()
    {
        if (_currentHealth <= 0)
        {
            IsAlive = false;
            animator.SetTrigger("Death");
            StartCoroutine(DelayDeathTrigger());
        }
    }

    private IEnumerator DelayDeathTrigger()
    {
        yield return new WaitForSeconds(_delayDeathTrigger);
        SetDeath();
    }

    private void OnEnable()
    {
        IsAlive = true;
    }

    protected abstract void SetDeath();
    protected abstract void UpdateHealthDisplay();
    protected abstract void SetDamageAnimation();
}
