using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private PlayerHealth _playerHealth;

    private void Awake()
    {
        _playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Spell":
                _playerHealth.GetDamage(other);
                break;
        }

        other.gameObject.SetActive(false);
    }
}