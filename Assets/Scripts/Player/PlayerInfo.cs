using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    private DragonController _dragonController;

    [SerializeField] private Text playerCoinsDisplay;
    public int Coins { get; private set; }
    public GameObject PlayerCoinsDisplay { get { return playerCoinsDisplay.gameObject; } }

    private void Awake()
    {
        _dragonController = FindObjectOfType<DragonController>();
        Coins = PlayerPrefs.GetInt("Coins");
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
        playerCoinsDisplay.text = Coins.ToString();
    }

    private void SaveCoins(Collider other)
    {
        Coins++;
        PlayerPrefs.SetInt("Coins", Coins);
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
