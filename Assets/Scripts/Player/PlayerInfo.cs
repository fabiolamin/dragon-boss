using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] private Text _playerArenasDisplay;

    public int WonArenas { get; private set; } = 1;

    private void Awake()
    {
        UpdateArenaDisplay();
        DragonController.DragonDeathHandler += AddArena;
    }

    private void UpdateArenaDisplay()
    {
        _playerArenasDisplay.text = WonArenas.ToString();
    }

    public void AddArena()
    {
        WonArenas++;
        UpdateArenaDisplay();
    }

    public void SaveArenas()
    {
        PlayerPrefs.SetInt("PlayerArenas", WonArenas - 1);
    }
}
