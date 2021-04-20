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

        if (playerCoinsAmount >= selectedHero.HeroData.Price)
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
        SaveHero(selectedHero.HeroData.Id);
        playerCoinsAmount = Mathf.Clamp(playerCoinsAmount - selectedHero.HeroData.Price, 0, PlayerPrefs.GetInt("Coins"));
        PlayerPrefs.SetInt("Coins", playerCoinsAmount);
        _heroSelection.UpdateHeroDisplayAfterPurchasing(playerCoinsAmount);
    }

    private void SaveHero(int id)
    {
        string heroesData = PlayerPrefs.GetString("Heroes");
        var heroList = JsonUtility.FromJson<HeroList>(heroesData);
        heroList.HeroesId.Add(id);
        heroesData = JsonUtility.ToJson(heroList);
        PlayerPrefs.SetString("Heroes", heroesData);
    }

    public bool IsHeroAlreadyPurchased(int id)
    {
        string heroesData = PlayerPrefs.GetString("Heroes");
        var heroList = JsonUtility.FromJson<HeroList>(heroesData);

        if (heroList.HeroesId.Count > 0)
        {
            foreach (var heroId in heroList.HeroesId)
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
