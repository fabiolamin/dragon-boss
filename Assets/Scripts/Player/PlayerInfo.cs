using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    private int wonArenas = 0;

    [SerializeField] private Text playerArenasDisplay;

    private void Awake()
    {
        UpdateArenaDisplay();
        DragonHealth.OnDragonDeath += AddArena;
        PlayerHealth.OnPlayerDeath += SaveArenas;
    }

    private void UpdateArenaDisplay()
    {
        playerArenasDisplay.text = wonArenas.ToString();
    }

    private void AddArena()
    {
        wonArenas++;
        UpdateArenaDisplay();
    }

    private void SaveArenas()
    {
        PlayerPrefs.SetInt("PlayerArenas", wonArenas);
    }
}
