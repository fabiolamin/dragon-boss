using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    private PlayerInfo _playerInfo;

    [SerializeField] private ParticleSystem _pickUpItemVFX;
    [SerializeField] private AudioClip _pickUpClip;
    [SerializeField] private SoundPlayer _soundPlayer;

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
                PlayEffects();
                _playerHealth.UpdateCurrentHealth(1f);
                break;
            case "Coin":
                PlayEffects();
                _playerInfo.SaveCoins(other);
                break;
            case "Spell Item":
                PlayEffects();
                SpellItem spellItem = other.GetComponent<SpellItem>();
                _playerInfo.UpdateAmountOfSpells(spellItem.SpellInfo.SpellName, 1);
                break;
        }

        other.gameObject.SetActive(false);
    }

    private void PlayEffects()
    {
        _pickUpItemVFX.Play();
        _soundPlayer.PlaySound(_pickUpClip);
    }
}
