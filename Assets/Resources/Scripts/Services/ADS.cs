using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class ADS : SingletonMonobehaviour<ADS>
{
    #region Variables

    string gameId = "1234567";
    string mySurfacingId = "rewardedVideo";
    bool testMode = true;

    #endregion

    #region MonoBehaviour Callbacks

    void Start()
    {
        Advertisement.Initialize(gameId, testMode);
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("Deaths") >= 3)
        {
            PlayerPrefs.SetInt("Deaths", 0);
            ShowRewardedVideo();
        }
    }

    #endregion

    #region Public Methods
    private void StopGame()
    {
        Music.Instance.StopMusic();
        SoundController.Instance.StopAll();
    }

    public void ShowRewardedVideo()
    {
        if (Advertisement.IsReady(mySurfacingId))
        {
            StopGame();
            ShowOptions options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show(mySurfacingId, options);
        }
        else
        {
            Debug.Log("Rewarded video is not ready at the moment! Please try again later!");
        }
        AnalyticsManager.Instance.ShowAd();
    }

    #endregion

    #region Private Methods

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                Music.Instance.PlayMusic();
                SceneManager.LoadScene("Post");

                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                Music.Instance.PlayMusic();
                SceneManager.LoadScene("Post");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }
    #endregion
}
