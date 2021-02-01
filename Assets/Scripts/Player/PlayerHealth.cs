using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    public delegate void PlayerDeath();
    public static event PlayerDeath PlayerDeathHandler;
    [SerializeField] private Text _healthDisplay;

    protected override void SetDeath()
    {
        //Set game over UI

        PlayerDeathHandler.Invoke();
        gameObject.SetActive(false);
    }

    protected override void UpdateHealthDisplay()
    {
        _healthDisplay.text = _currentHealth.ToString();
    }
}
