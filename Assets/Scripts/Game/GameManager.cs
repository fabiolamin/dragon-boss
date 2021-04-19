using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private AudioOptions _audioOptions;

    private void Awake()
    {
        _audioOptions = FindObjectOfType<AudioOptions>();

        if (PlayerPrefs.GetInt("FirstPlay") == 0)
        {
            PlayerPrefs.SetFloat("Music", _audioOptions.MaxMusicVolume);
            PlayerPrefs.SetFloat("Sound", _audioOptions.MaxSoundVolume);
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