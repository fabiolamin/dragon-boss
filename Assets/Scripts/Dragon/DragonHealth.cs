using UnityEngine;

public class DragonHealth : Health
{
    protected override void SetDeath()
    {
        Debug.Log("Dragon Dead!");
    }
}
