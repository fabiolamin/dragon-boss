using UnityEngine;

public class SpellItem : Item
{
    [SerializeField] private SpellInfo _spellInfo;

    protected override void SetBonus(Player player)
    {
        PlayerInfo playerInfo = player.GetComponent<PlayerInfo>();
        playerInfo.UpdateAmountOfSpells(_spellInfo.SpellName, 1);
    }
}
