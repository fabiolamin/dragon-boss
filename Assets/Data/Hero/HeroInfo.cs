using UnityEngine;

[CreateAssetMenu(fileName = "HeroInfo", menuName = "New Hero Info")]
public class HeroInfo : ScriptableObject
{
    [SerializeField] private int _id;
    [SerializeField] private string _name;
    [SerializeField] private int _price;

    public int Id { get; private set; }
    public string Name { get; private set; }
    public int Price { get; private set; }
}
