using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private HeroInfo _heroInfo;
    public HeroInfo HeroInfo { get { return _heroInfo; } }
}
