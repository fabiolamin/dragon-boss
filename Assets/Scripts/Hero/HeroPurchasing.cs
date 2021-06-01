using System.Linq;
using UnityEngine;

public class HeroPurchasing : MonoBehaviour
{
    [SerializeField] private HeroSelection _heroSelection;

    public void PurchaseHero()
    {
        Hero selectedHero = _heroSelection.Heroes.Single(h => h.gameObject.activeSelf);
        int playerCoinsAmount = GameDataController.Instance.GameData.Coins;

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
        GameDataController.Instance.SaveCoins(playerCoinsAmount - selectedHero.HeroData.Price);
        _heroSelection.UpdateHeroDisplayAfterPurchasing(playerCoinsAmount);
    }

    private void SaveHero(int id)
    {
        string heroesData = GameDataController.Instance.GameData.HeroesData;
        var heroList = JsonUtility.FromJson<HeroList>(heroesData);
        heroList.HeroesId.Add(id);
        heroesData = JsonUtility.ToJson(heroList);
        GameDataController.Instance.SaveHeroesData(heroesData);
    }

    public bool IsHeroAlreadyPurchased(int id)
    {
        string heroesData = GameDataController.Instance.GameData.HeroesData;
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
