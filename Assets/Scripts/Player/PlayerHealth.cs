using UnityEngine;

public class PlayerHealth : Health
{
    protected override void SetDeath()
    {
        Debug.Log("Player Dead!");
    }
}
