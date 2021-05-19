using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class PlayGamesService : MonoBehaviour
{
    private static PlayGamesService _instance;

    public delegate void WarningAuthenticationHandler(string text);
    public event WarningAuthenticationHandler WarningAuthentication;

    public static PlayGamesService Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Play Games Service is NULL");
            }

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
        Initialize();
    }

    private void Initialize()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
        .EnableSavedGames()
        .RequestServerAuthCode(false)
        .Build();

        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();

        PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptOnce, (result) => { });
    }

    public void SignIn()
    {
        if(!Social.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptAlways, (result) =>
            {
                if (result == SignInStatus.Success)
                {
                    WarningAuthentication?.Invoke("You are connected!");
                }

                else
                {
                    WarningAuthentication?.Invoke("An error has occurred, please check your network connection and try again later.");
                }
            });
        }
        else
        {
            WarningAuthentication?.Invoke("You are already connected!");
        }
    }

    public void ShowLeaderboard()
    {
        if (Social.localUser.authenticated)
        {
            Social.ReportScore(PlayerPrefs.GetInt("HighScore"), GPGSIds.leaderboard_max_dragons_defeated, success => { });
            Social.ShowLeaderboardUI();
        }
        else
        {
            WarningAuthentication?.Invoke("Please, connect to Play Games in order to see the leaderboard.");
        }
    }
}
