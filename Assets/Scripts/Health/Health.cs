using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] protected float _currentHealth;
    [SerializeField] protected float health = 3f;

    private void Awake()
    {
        _currentHealth = health;
        UpdateHealthDisplay();
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Spell":
                Spell spell = other.gameObject.GetComponent<Spell>();
                UpdateCurrentHealth(-spell.SpellInfo.Damage);
                break;
            case "Life":
                UpdateCurrentHealth(1f);
                break;
        }

        other.gameObject.SetActive(false);
    }

    protected void GetDamage(Collider other)
    {
        UpdateCurrentHealth(-1f);
        other.gameObject.SetActive(false);
    }

    protected void UpdateCurrentHealth(float amount)
    {
        if (!SceneLoader.IsLoading)
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
            SetDeath();
        }
    }

    protected abstract void SetDeath();
    protected abstract void UpdateHealthDisplay();
}
