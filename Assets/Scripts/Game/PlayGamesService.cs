using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using Newtonsoft.Json;
using System.Text;
using UnityEngine.SceneManagement;
using System;

public class PlayGamesService : MonoBehaviour
{
    private bool isSavingToCloud = false;

    public delegate void WarningMessageHandler(string text);
    public event WarningMessageHandler WarningMessage;

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
            NotifyWarningMessage("Connecting . . .");

            PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptAlways, (result) =>
            {
                if (result == SignInStatus.Success)
                {
                    SceneManager.LoadScene(0);
                }

                else
                {
                    NotifyWarningMessage("An error has occurred, please check your network connection and try again later.");
                }
            });
        }
    }

    public void SaveHighScore(int score)
    {
        if (Social.localUser.authenticated)
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
            NotifyWarningMessage("Please, connect to Play Games to see the leaderboards.");
        }
    }

    public void OpenSavedGame(bool isSaving, string fileName)
    {
        if (Social.localUser.authenticated)
        {
            isSavingToCloud = isSaving;

            ISavedGameClient savedGameClient = PlayGamesPlatform.Instance.SavedGame;

            savedGameClient.OpenWithAutomaticConflictResolution(fileName, DataSource.ReadCacheOrNetwork,
                ConflictResolutionStrategy.UseLongestPlaytime, OnSavedGameOpened);
        }
        else
        {
            if (!isSaving)
            {
                NotifyWarningMessage("Please, connect to Play Games to load the saved game.");
            }
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
        else
        {
            NotifyWarningMessage("An error has occurred, please try again later.");
        }
    }

    private void SaveGame(ISavedGameMetadata game, byte[] savedData)
    {
        ISavedGameClient savedGameClient = PlayGamesPlatform.Instance.SavedGame;
        SavedGameMetadataUpdate.Builder builder = new SavedGameMetadataUpdate.Builder();
        builder = builder
            .WithUpdatedDescription("Saved game at " + DateTime.Now);

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
            //Success
        }
        else
        {
            //Fail
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
                SceneManager.LoadScene(0);
            }
            else
            {
                NotifyWarningMessage("No saved game found.");
            }
        }
        else
        {
            NotifyWarningMessage("Error to load the saved game. Please, try again later.");
        }
    }

    public void NotifyWarningMessage(string message)
    {
        WarningMessage?.Invoke(message);
    }

    public void ShowSelectUI()
    {
        if(Social.localUser.authenticated)
        {
            uint maxNumToDisplay = 3;
            bool allowCreateNew = false;
            bool allowDelete = true;

            ISavedGameClient savedGameClient = PlayGamesPlatform.Instance.SavedGame;
            savedGameClient.ShowSelectSavedGameUI("Select saved game",
                maxNumToDisplay,
                allowCreateNew,
                allowDelete,
                OnSavedGameSelected);
        }
        else
        {
            NotifyWarningMessage("Please, connect to Play Games to select a saved game.");
        }
    }


    public void OnSavedGameSelected(SelectUIStatus status, ISavedGameMetadata game)
    {
        if (status == SelectUIStatus.SavedGameSelected)
        {
            NotifyWarningMessage("Loading . . .");
            OpenSavedGame(false, game.Filename);
        }
        else
        {
            // handle cancel or error
        }
    }
}
