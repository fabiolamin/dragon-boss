using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    private int arenas = 0;

    [SerializeField] private Text arenaDisplay;

    private void Awake()
    {
        UpdateArenaDisplay();
        DragonHealth.OnDragonDeath += AddArena;
    }

    private void UpdateArenaDisplay()
    {
        arenaDisplay.text = arenas.ToString();
    }

    private void AddArena()
    {
        arenas++;
        UpdateArenaDisplay();
    }

    public void SaveArenas()
    {
        PlayerPrefs.SetInt("PlayerArenas", arenas);
    }
}
