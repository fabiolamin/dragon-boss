using UnityEngine;
using System.Collections;

public abstract class Health : MonoBehaviour
{
    protected Animator animator;
    [SerializeField] protected float _currentHealth;
    [SerializeField] protected float health = 3f;

    public bool IsAlive { get; private set; } = true;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        _currentHealth = health;
        UpdateHealthDisplay();
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Spell":
                GetDamage(other);
                break;
            case "Life":
                UpdateCurrentHealth(1f);
                break;
        }

        other.gameObject.SetActive(false);
    }

    private void GetDamage(Collider other)
    {
        if (IsAlive)
        {
            animator.SetTrigger("Damage");
            Spell spell = other.gameObject.GetComponent<Spell>();
            UpdateCurrentHealth(-spell.SpellInfo.Damage);
        }
    }

    protected void UpdateCurrentHealth(float amount)
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
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        SetDeath();
    }

    private void OnEnable()
    {
        IsAlive = true;
    }

    protected abstract void SetDeath();
    protected abstract void UpdateHealthDisplay();
}
