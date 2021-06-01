using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using Newtonsoft.Json;
using System.Text;
using UnityEngine.SceneManagement;

public class PlayGamesService : MonoBehaviour
{
    private bool isSavingToCloud = false;
    private const string SAVE_NAME = "DRAGON_BOSS";

    public delegate void WarningAuthenticationHandler(string text);
    public event WarningAuthenticationHandler WarningAuthentication;

    public delegate string SavedGameUpdateHandler();
    public event SavedGameUpdateHandler SavedGameUpdate;

    public delegate void SavedGameReadHandler(string data);
    public event SavedGameReadHandler SavedGameRead;

    private void Awake()
    {
        Initialize();
    }

    public void Initialize()
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
        if (!Social.localUser.authenticated)
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

    public void SaveHighScore(int score)
    {
        if(Social.localUser.authenticated)
        {
            Social.ReportScore(score, GPGSIds.leaderboard_max_dragons_defeated, success => { });
        }
    }

    public void ShowLeaderboard()
    {
        if (Social.localUser.authenticated)
        {
            GameData gameData = JsonConvert.DeserializeObject<GameData>(PlayerPrefs.GetString("GameData"));
            SaveHighScore(gameData.HighScore);
            Social.ShowLeaderboardUI();
        }
        else
        {
            WarningAuthentication?.Invoke("Please, connect to Play Games to see the leaderboard.");
        }
    }

    public void OpenSavedGame(bool isSaving)
    {
        if(Social.localUser.authenticated)
        {
            isSavingToCloud = isSaving;

            ISavedGameClient savedGameClient = PlayGamesPlatform.Instance.SavedGame;

            savedGameClient.OpenWithAutomaticConflictResolution(SAVE_NAME, DataSource.ReadCacheOrNetwork,
                ConflictResolutionStrategy.UseLongestPlaytime, OnSavedGameOpened);
        }
    }

    private void OnSavedGameOpened(SavedGameRequestStatus status, ISavedGameMetadata meta)
    {
        if (status == SavedGameRequestStatus.Success)
        {
            if (isSavingToCloud)
            {
                SaveGame(meta, Encoding.ASCII.GetBytes(PlayerPrefs.GetString("GameData")));
            }
            else
            {
                LoadGameData(meta);
            }
        }
    }

    private void SaveGame(ISavedGameMetadata game, byte[] savedData)
    {
        ISavedGameClient savedGameClient = PlayGamesPlatform.Instance.SavedGame;
        SavedGameMetadataUpdate.Builder builder = new SavedGameMetadataUpdate.Builder();
        SavedGameMetadataUpdate updatedMetadata = builder.Build();

        savedGameClient.CommitUpdate(game, updatedMetadata, savedData, OnSavedGameWritten);
    }

    private void LoadGameData(ISavedGameMetadata game)
    {
        ISavedGameClient savedGameClient = PlayGamesPlatform.Instance.SavedGame;
        savedGameClient.ReadBinaryData(game, OnSavedGameDataRead);
    }

    private void OnSavedGameWritten(SavedGameRequestStatus status, ISavedGameMetadata meta)
    {
        if (status == SavedGameRequestStatus.Success)
        {
            WarningAuthentication?.Invoke("Game Data saved with success!");
        }
        else
        {
            WarningAuthentication?.Invoke("Game Data saved with failed!");
        }
    }

    private void OnSavedGameDataRead(SavedGameRequestStatus status, byte[] data)
    {
        if (status == SavedGameRequestStatus.Success)
        {
            string dataString = Encoding.UTF8.GetString(data);
            GameData gameData = JsonConvert.DeserializeObject<GameData>(dataString);

            if (gameData != null)
            {
                PlayerPrefs.SetString("GameData", dataString);
                WarningAuthentication?.Invoke("Game Data read with success! : " + dataString);
                SceneManager.LoadScene(0);
            }
        }
        else
        {
            WarningAuthentication?.Invoke("Game Data read with failed!");
        }
    }
}
