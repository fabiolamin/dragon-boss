using UnityEngine;
using UnityEngine.UI;

public abstract class Health : MonoBehaviour
{
    [SerializeField] protected float health = 3f;

    private void OnTriggerEnter(Collider other)
    {
        GetDamage(1f);
        other.gameObject.SetActive(false);
    }

    public void GetDamage(float amount)
    {
        health -= amount;
        UpdateHealthDisplay();
        CheckHealth();
    }

    private void CheckHealth()
    {
        if(health <= 0)
        {
            SetDeath();
        }
    }

    protected abstract void SetDeath();
    protected abstract void UpdateHealthDisplay();
}
