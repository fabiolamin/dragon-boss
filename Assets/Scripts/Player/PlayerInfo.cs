using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] private Text _playerArenasDisplay;

    public int CurrentArena { get; private set; } = 1;

    private void Awake()
    {
        UpdateArenaDisplay();
        DragonController.DragonDeathHandler += AddArena;
    }

    private void UpdateArenaDisplay()
    {
        _playerArenasDisplay.text = CurrentArena.ToString();
    }

    public void AddArena()
    {
        CurrentArena++;
        UpdateArenaDisplay();
    }

    public void SaveWonArenas()
    {
        int wonArenas = CurrentArena - 1;

        if ((wonArenas) > PlayerPrefs.GetInt("HighArena"))
            PlayerPrefs.SetInt("HighArena", wonArenas);
    }
}
