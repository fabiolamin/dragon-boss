using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] private Text _playerArenasDisplay;

    public static int WonArenas { get; private set; } = 1;

    private void Awake()
    {
        UpdateArenaDisplay();
        DragonController.DragonDeathHandler += AddArena;
        PlayerHealth.PlayerDeathHandler += SaveArenas;
    }

    private void UpdateArenaDisplay()
    {
        _playerArenasDisplay.text = WonArenas.ToString();
    }

    private void AddArena()
    {
        WonArenas++;
        UpdateArenaDisplay();
    }

    private void SaveArenas()
    {
        PlayerPrefs.SetInt("PlayerArenas", WonArenas);
    }
}
