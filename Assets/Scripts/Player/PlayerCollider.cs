using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    private PlayerInfo _playerInfo;

    private void Awake()
    {
        _playerHealth = GetComponent<PlayerHealth>();
        _playerInfo = GetComponent<PlayerInfo>();
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Spell":
                _playerHealth.GetDamage(other);
                break;
            case "Life":
                _playerHealth.UpdateCurrentHealth(1f);
                break;
            case "Coin":
                _playerInfo.SaveCoins(other);
                break;
        }

        other.gameObject.SetActive(false);
    }
}
