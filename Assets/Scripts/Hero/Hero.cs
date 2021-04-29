using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private HeroData _heroData;

    public HeroData HeroData { get { return _heroData; } }

    public void SetDeath()
    {
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();

        if(playerHealth != null)
        {
            playerHealth.SetDeath();
        }
    }
}
