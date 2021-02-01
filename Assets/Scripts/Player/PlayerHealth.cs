using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    public delegate void PlayerDeath();
    public static event PlayerDeath OnPlayerDeath;
    [SerializeField] private Text _healthDisplay;

    protected override void SetDeath()
    {
        //Save player's arena score
        //Set game over UI

        OnPlayerDeath.Invoke();
    }

    protected override void UpdateHealthDisplay()
    {
        _healthDisplay.text = _currentHealth.ToString();
    }
}
