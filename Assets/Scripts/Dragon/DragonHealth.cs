using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DragonHealth : Health
{
    private Animator _animator;
    [SerializeField] private Text _healthDisplay;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    protected override void SetDeath()
    {
        _animator.SetTrigger("Death");
        StartCoroutine(DelayDeathTrigger());
    }

    private IEnumerator DelayDeathTrigger()
    {
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
        gameObject.SetActive(false);
        DragonController.OnDragonDeath();
    }

    protected override void UpdateHealthDisplay()
    {
        _healthDisplay.text = _currentHealth.ToString();
    }

    public void IncreaseHealth(float amount)
    {
        health += amount;
        _currentHealth = health;
        UpdateHealthDisplay();
    }
}
