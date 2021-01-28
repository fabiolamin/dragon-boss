using UnityEngine;
using UnityEngine.UI;

public abstract class Health : MonoBehaviour
{
    [SerializeField] protected float _currentHealth;
    [SerializeField] protected float health = 3f;

    private void Awake()
    {
        _currentHealth = health;
    }

    private void OnTriggerEnter(Collider other)
    {
        UpdateHealth(-1f);
        other.gameObject.SetActive(false);
    }

    public void UpdateHealth(float amount)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + amount, 0, health);
        UpdateHealthDisplay();
        CheckHealth();
    }

    private void CheckHealth()
    {
        if(_currentHealth <= 0)
        {
            SetDeath();
        }
    }

    protected abstract void SetDeath();
    protected abstract void UpdateHealthDisplay();
}
