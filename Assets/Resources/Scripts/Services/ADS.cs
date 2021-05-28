using UnityEngine;
using UnityEngine.Advertisements;

public class ADS : SingletonMonobehaviour<ADS>
{
    string gameId = "1234567";
    string mySurfacingId = "rewardedVideo";
    bool testMode = true;

    // Initialize the Ads listener and service:
    void Start()
    {
        Advertisement.Initialize(gameId, testMode);
    }

    public void ShowRewardedVideo()
    {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady(mySurfacingId))
        {
            Advertisement.Show(mySurfacingId);
        }
        else
        {
            Debug.Log("Rewarded video is not ready at the moment! Please try again later!");
        }
    }

   
}
