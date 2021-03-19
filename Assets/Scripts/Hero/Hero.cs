using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private int _id;
    [SerializeField] private string _name;
    [SerializeField] private int _price;

    public int Id { get { return _id; } }
    public string Name { get { return _name; } }
    public int Price { get { return _price; } }
}
