using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameData
{
    public int HighScore { get; set; }
    public int Coins { get; set; }
    public int Hero { get; set; }
    public string HeroesData { get; set; }
    public SpellInfo[] Spells { get; set; }

    public GameData()
    {
        HighScore = 0;
        Coins = 0;
        Hero = 1;

        HeroList heroList = new HeroList();
        heroList.HeroesId = new List<int>() { 1 };
        string heroesData = JsonUtility.ToJson(heroList);

        HeroesData = heroesData;

        Spells = new SpellInfo[5];
        Spells[0] = new SpellInfo(1, 0);
        Spells[1] = new SpellInfo(2, 0);
        Spells[2] = new SpellInfo(3, 0);
        Spells[3] = new SpellInfo(4, 0);
        Spells[4] = new SpellInfo(5, 0);
    }
}
