using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    private DragonController _dragonController;

    private void Awake()
    {
        _dragonController = FindObjectOfType<DragonController>();
    }
    public void SaveHighDefeatedDragon()
    {
        int wonArenas = _dragonController.CurrentDragon - 1;

        if ((wonArenas) > PlayerPrefs.GetInt("MaxDragon"))
            PlayerPrefs.SetInt("MaxDragon", wonArenas);
    }
}
