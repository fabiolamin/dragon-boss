using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    private DragonController _dragonController;
    private int coins;

    private void Awake()
    {
        _dragonController = FindObjectOfType<DragonController>();
        coins = PlayerPrefs.GetInt("Coins");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            SaveCoins(other);
        }
    }

    private void SaveCoins(Collider other)
    {
        coins++;
        PlayerPrefs.SetInt("Coins", coins);
        other.gameObject.SetActive(false);
    }

    public void SaveHighDefeatedDragon()
    {
        int wonArenas = _dragonController.CurrentDragon - 1;

        if ((wonArenas) > PlayerPrefs.GetInt("MaxDragon"))
            PlayerPrefs.SetInt("MaxDragon", wonArenas);
    }
}
