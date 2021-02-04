using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    private DragonController _dragonController;
    private int coins;

    [SerializeField] private Text playerCoinsDisplay;

    private void Awake()
    {
        _dragonController = FindObjectOfType<DragonController>();
        coins = PlayerPrefs.GetInt("Coins");
        UpdatePlayerCoinsDisplay();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            SaveCoins(other);
        }
    }

    private void UpdatePlayerCoinsDisplay()
    {
        playerCoinsDisplay.text = coins.ToString();
    }

    private void SaveCoins(Collider other)
    {
        coins++;
        PlayerPrefs.SetInt("Coins", coins);
        UpdatePlayerCoinsDisplay();
        other.gameObject.SetActive(false);
    }

    public void SaveHighDefeatedDragon()
    {
        int wonArenas = _dragonController.CurrentDragon - 1;

        if ((wonArenas) > PlayerPrefs.GetInt("MaxDragon"))
            PlayerPrefs.SetInt("MaxDragon", wonArenas);
    }
}
