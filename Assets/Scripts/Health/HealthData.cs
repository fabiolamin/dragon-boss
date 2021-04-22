using UnityEngine;

[CreateAssetMenu(fileName = "Health Data", menuName = "New Health Data")]
public class HealthData : ScriptableObject
{
    [SerializeField] private float _health;
    [SerializeField] protected float _delayDeathTrigger;

    public float Health { get { return _health; } }
    public float DelayDeathTrigger { get { return _delayDeathTrigger; } }
}
