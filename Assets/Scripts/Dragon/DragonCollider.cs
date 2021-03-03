using UnityEngine;

public class DragonCollider : MonoBehaviour
{
    private DragonHealth _dragonHealth;

    private void Awake()
    {
        _dragonHealth = GetComponent<DragonHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Spell":
                _dragonHealth.GetDamage(other);
                break;
        }

        other.gameObject.SetActive(false);
    }
}
