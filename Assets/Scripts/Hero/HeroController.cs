using System.Linq;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    [SerializeField] private Hero[] _heroes;
    public GameObject Hero { get; private set; }
    public Animator HeroAnimator { get; private set; }

    private void Awake()
    {
        SpawnHero();
    }

    private void SpawnHero()
    {
        int currentHeroId = PlayerPrefs.GetInt("Hero");
        Hero availableHero = _heroes.Single(h => h.Id == currentHeroId);
        Hero = Instantiate(availableHero, transform.position, Quaternion.identity, transform).gameObject;
        Hero.SetActive(true);
        HeroAnimator = Hero.GetComponent<Animator>();
    }
}