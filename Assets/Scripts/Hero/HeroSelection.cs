using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections;

public class HeroSelection : MonoBehaviour
{
    private HeroPurchasing _heroPurchasing;
    private int _heroesIndex = 0;
    [SerializeField] private Hero[] _heroesPrefab;
    [SerializeField] private Transform _storeHeroPlaceholder;
    [SerializeField] private Transform _selectedHeroPlaceholder;
    [SerializeField] private Text _heroNameDisplay;
    [SerializeField] private Text _heroPriceDisplay;
    [SerializeField] private Text _playerCoinsDisplay;
    [SerializeField] private GameObject _selectButton, _buyButton, _selectedDisplay, _notificationDisplay;
    [SerializeField] private float _notificationDelay = 3f;

    public List<Hero> Heroes { get; private set; } = new List<Hero>();

    private void Start()
    {
        _heroPurchasing = GetComponent<HeroPurchasing>();
        SpawnHeroes();
        ShowSelectedHero();
    }

    private void SpawnHeroes()
    {
        var orderedHeroes = _heroesPrefab.OrderBy(h => h.HeroData.Price).ToList();

        foreach (var heroPrefab in orderedHeroes)
        {
            Hero hero = Instantiate(heroPrefab, _storeHeroPlaceholder.position, _storeHeroPlaceholder.rotation, transform);
            hero.transform.localScale = _storeHeroPlaceholder.localScale;
            Heroes.Add(hero);
            hero.gameObject.SetActive(false);
        }
    }

    public void ShowSelectedHero()
    {
        Heroes.ForEach(h => h.gameObject.SetActive(false));
        Hero selectedHero = Heroes.Single(h => h.HeroData.Id == PlayerPrefs.GetInt("Hero"));
        SetHeroTransform(selectedHero, _selectedHeroPlaceholder);
    }

    private void SetHeroTransform(Hero hero, Transform tr)
    {
        hero.gameObject.SetActive(true);
        hero.transform.position = tr.position;
        hero.transform.localScale = tr.localScale;
        hero.transform.rotation = tr.rotation;
    }

    public void ShowHero(int direction)
    {
        _heroesIndex = Mathf.Clamp(_heroesIndex + direction, 0, Heroes.Count - 1);
        DisableHeroDisplay();
        Hero hero = Heroes[_heroesIndex];
        hero.gameObject.SetActive(true);
        SetUpHeroDisplay(hero);
    }

    private void SetUpHeroDisplay(Hero hero)
    {
        _heroNameDisplay.text = hero.HeroData.Name;

        if (_heroPurchasing.IsHeroAlreadyPurchased(hero.HeroData.Id))
        {
            ShowPurchasedHero(hero);
        }
        else
        {
            _buyButton.SetActive(true);
            _heroPriceDisplay.gameObject.SetActive(true);
            _heroPriceDisplay.text = hero.HeroData.Price.ToString();
        }
    }

    private void ShowPurchasedHero(Hero hero)
    {
        _selectButton.SetActive(true);
        _buyButton.SetActive(false);
        _heroPriceDisplay.gameObject.SetActive(false);

        if (hero.HeroData.Id == PlayerPrefs.GetInt("Hero"))
        {
            _selectButton.SetActive(false);
            _selectedDisplay.SetActive(true);
        }
    }

    public void SelectHero()
    {
        Hero hero = Heroes.Single(h => h.gameObject.activeSelf);
        PlayerPrefs.SetInt("Hero", hero.HeroData.Id);
        _selectButton.SetActive(false);
        _selectedDisplay.SetActive(true);
    }

    private void DisableHeroDisplay()
    {
        _notificationDisplay.SetActive(false);
        _selectButton.SetActive(false);
        _buyButton.SetActive(false);
        _heroPriceDisplay.gameObject.SetActive(false);
        _selectedDisplay.SetActive(false);
        Heroes.ForEach(h => h.gameObject.SetActive(false));
    }

    public void ResetHeroes()
    {
        foreach (var hero in Heroes)
        {
            SetHeroTransform(hero, _storeHeroPlaceholder);
        }
    }

    public IEnumerator ShowNotification()
    {
        _notificationDisplay.SetActive(true);
        yield return new WaitForSeconds(_notificationDelay);
        _notificationDisplay.SetActive(false);
    }

    public void UpdateHeroDisplayAfterPurchasing(int playerCoinsAmount)
    {
        _playerCoinsDisplay.text = playerCoinsAmount.ToString();
        _buyButton.SetActive(false);
        _heroPriceDisplay.gameObject.SetActive(false);
        _selectButton.SetActive(true);
    }
}
