using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    public delegate void PlayerDeath();
    public static event PlayerDeath OnPlayerDeath;
    [SerializeField] private Text _healthDisplay;

    protected override void SetDeath()
    {
        //Set game over UI

        OnPlayerDeath.Invoke();
        gameObject.SetActive(false);
    }

    protected override void UpdateHealthDisplay()
    {
        _healthDisplay.text = _currentHealth.ToString();
    }
}
