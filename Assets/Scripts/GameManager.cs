using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        if (PlayerPrefs.GetInt("FirstPlay") == 0)
        {
            PlayerPrefs.SetFloat("Music", 1);
            PlayerPrefs.SetFloat("Sounds", 1);

            PlayerPrefs.SetInt("FirstPlay", 1);
        }
    }
}
