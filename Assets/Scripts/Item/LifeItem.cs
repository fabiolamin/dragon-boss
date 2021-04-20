using UnityEngine;

public class LifeItem : Item
{
    [SerializeField] private float _lifeBonus = 1f;
    protected override void SetBonus(Player player)
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        playerHealth.UpdateCurrentHealth(_lifeBonus);
    }
}
