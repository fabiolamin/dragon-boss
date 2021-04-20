using UnityEngine;

public class CoinItem : Item
{
    protected override void SetBonus(Player player)
    {
        PlayerInfo playerInfo = player.GetComponent<PlayerInfo>();
        playerInfo.SaveCoins();
    }
}