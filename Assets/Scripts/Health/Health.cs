using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] protected float health = 3f;

    private void OnTriggerEnter(Collider other)
    {
        GetDamage(1f);    
    }

    public void GetDamage(float amount)
    {
        health -= amount;
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
}
