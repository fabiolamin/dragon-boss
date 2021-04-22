using UnityEngine;
using System.Collections;

public abstract class Health : MonoBehaviour
{
    protected Animator animator;
    protected float maxHealth;
    protected float currentHealth;

    [SerializeField] protected HealthData healthData;
    [SerializeField] protected SoundPlayer soundPlayer;
    [SerializeField] protected ParticleSystem damageVFX;
    [SerializeField] protected AudioClip _damageClip;
    public bool IsAlive { get; private set; } = true;

    private void Awake()
    {
        maxHealth = healthData.Health;
        currentHealth = healthData.Health;
        UpdateHealthDisplay();
    }

    private void Update()
    {
        animator.SetBool("IsAlive", IsAlive);
    }

    private void OnTriggerEnter(Collider other)
    {
        Spell spell = other.gameObject.GetComponent<Spell>();

        if (spell != null)
        {
            GetDamage(spell.SpellData.Damage);
            other.gameObject.SetActive(false);
        }
    }

    public void GetDamage(float amount)
    {
        if (IsAlive)
        {
            soundPlayer.PlaySound(_damageClip);
            damageVFX.Play();
            SetDamageAnimation();
            UpdateCurrentHealth(-amount);
        }
    }

    public void UpdateCurrentHealth(float amount)
    {
        if (!SceneLoader.IsLoading && IsAlive)
        {
            currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
            UpdateHealthDisplay();
            CheckHealth();
        }
    }

    private void CheckHealth()
    {
        if (currentHealth <= 0)
        {
            IsAlive = false;
            StartCoroutine(DelayDeathTrigger());
        }
    }

    private IEnumerator DelayDeathTrigger()
    {
        yield return new WaitForSeconds(healthData.DelayDeathTrigger);
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
