using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private HeroData _heroData;

    public HeroData HeroData { get { return _heroData; } }
}
