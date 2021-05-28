using UnityEngine;
using UnityEngine.Advertisements;

public class ADS : SingletonMonobehaviour<ADS>
{
    string gameId = "1234567";
    string mySurfacingId = "rewardedVideo";
    bool testMode = true;

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

    public void ShowRewardedVideo()
    {
        if (Advertisement.IsReady(mySurfacingId))
        {
            Advertisement.Show(mySurfacingId);
        }
        else
        {
            Debug.Log("Rewarded video is not ready at the moment! Please try again later!");
        }
        AnalyticsManager.Instance.ShowAd();
    }


}
