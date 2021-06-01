using UnityEngine;

public class SpellItem : Item
{
    [SerializeField] private SpellData _spellData;

    protected override void SetBonus(Player player)
    {
        PlayerInfo playerInfo = player.GetComponent<PlayerInfo>();
        playerInfo.UpdateAmountOfSpells(_spellData.Id, 1);
    }
}
