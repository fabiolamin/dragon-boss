using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    private PlayerInfo _playerInfo;

    [SerializeField] private ParticleSystem _pickUpItemVFX;

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
                _pickUpItemVFX.Play();
                _playerHealth.UpdateCurrentHealth(1f);
                break;
            case "Coin":
                _pickUpItemVFX.Play();
                _playerInfo.SaveCoins(other);
                break;
            case "Spell Item":
                _pickUpItemVFX.Play();
                SpellItem spellItem = other.GetComponent<SpellItem>();
                _playerInfo.UpdateAmountOfSpells(spellItem.SpellInfo.SpellName, 1);
                break;
        }

        other.gameObject.SetActive(false);
    }
}
