using System;

[Serializable]
public class SpellInfo
{
    public int Id { get; set; }
    public int Amount { get; set; }

    public SpellInfo(int id, int amount)
    {
        Id = id;
        Amount = amount;
    }
}
