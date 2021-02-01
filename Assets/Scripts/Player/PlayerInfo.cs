using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    private int _wonArenas = 0;

    [SerializeField] private Text _playerArenasDisplay;

    private void Awake()
    {
        UpdateArenaDisplay();
        DragonHealth.OnDragonDeath += AddArena;
        PlayerHealth.OnPlayerDeath += SaveArenas;
    }

    private void UpdateArenaDisplay()
    {
        _playerArenasDisplay.text = _wonArenas.ToString();
    }

    private void AddArena()
    {
        _wonArenas++;
        UpdateArenaDisplay();
    }

    private void SaveArenas()
    {
        PlayerPrefs.SetInt("PlayerArenas", _wonArenas);
    }
}
