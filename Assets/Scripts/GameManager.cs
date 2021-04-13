using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        if (PlayerPrefs.GetInt("FirstPlay") == 0)
        {
            PlayerPrefs.SetFloat("Music", 1);
            PlayerPrefs.SetFloat("Sound", 1);
            PlayerPrefs.SetInt("Hero", 1);
            PlayerPrefs.SetInt("FirstPlay", 1);
            PlayerPrefs.SetInt("Coins", 1000);

            HeroesData heroesData = new HeroesData();
            heroesData.HeroesId = new List<int>() { 1 };
            string heroesIdJson = JsonUtility.ToJson(heroesData);
            PlayerPrefs.SetString("Heroes", heroesIdJson);
        }
    }
}
