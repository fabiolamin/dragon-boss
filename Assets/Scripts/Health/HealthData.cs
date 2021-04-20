using UnityEngine;

[CreateAssetMenu(fileName = "New Health Data", menuName = "Health Data")]
public class HealthData : ScriptableObject
{
    [SerializeField] private float _health;
    [SerializeField] protected float _delayDeathTrigger;

    public float Health { get { return _health; } set { _health = value; } }
    public float DelayDeathTrigger { get { return _delayDeathTrigger; } }
}
