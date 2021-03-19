using System.Linq;
using UnityEngine;

public class HeroPurchasing : MonoBehaviour
{
    private HeroSelection _heroSelection;

    private void Start()
    {
        _heroSelection = GetComponent<HeroSelection>();
    }

    public void PurchaseHero()
    {
        Hero selectedHero = _heroSelection.Heroes.Single(h => h.gameObject.activeSelf);
        int playerCoinsAmount = PlayerPrefs.GetInt("Coins");

        if (playerCoinsAmount >= selectedHero.Price)
        {
            CompletePurchasing(selectedHero, playerCoinsAmount);
        }
        else
        {
            StartCoroutine(_heroSelection.ShowNotification());
        }
    }

    private void CompletePurchasing(Hero selectedHero, int playerCoinsAmount)
    {
        SaveHero(selectedHero.Id);
        playerCoinsAmount = Mathf.Clamp(playerCoinsAmount - selectedHero.Price, 0, PlayerPrefs.GetInt("Coins"));
        PlayerPrefs.SetInt("Coins", playerCoinsAmount);
        _heroSelection.UpdateHeroDisplayAfterPurchasing(playerCoinsAmount);
    }

    private void SaveHero(int id)
    {
        string heroesDataJson = PlayerPrefs.GetString("Heroes");
        var heroesData = JsonUtility.FromJson<HeroesData>(heroesDataJson);
        heroesData.HeroesId.Add(id);
        heroesDataJson = JsonUtility.ToJson(heroesData);
        PlayerPrefs.SetString("Heroes", heroesDataJson);
    }

    public bool IsHeroAlreadyPurchased(int id)
    {
        string heroesDataJson = PlayerPrefs.GetString("Heroes");
        var heroesData = JsonUtility.FromJson<HeroesData>(heroesDataJson);

        if (heroesData.HeroesId.Count > 0)
        {
            foreach (var heroId in heroesData.HeroesId)
            {
                if (id == heroId)
                {
                    return true;
                }
            }
        }

        return false;
    }
}
