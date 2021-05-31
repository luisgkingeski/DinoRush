using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class AnalyticsManager : SingletonMonobehaviour<AnalyticsManager>
{
    #region References

    private ProgressBar progressBar;

    #endregion

    #region Variables

    private string progress;

    #endregion

    #region MonoBehaviour Callbacks

    private void Start()
    {
        progressBar = ProgressBar.Instance;
    }

    private void Update()
    {
        SetLimits();
    }

    #endregion

    #region Private Methods


    private void SetLimits()
    {
        int progressValue = (int)progressBar.distancePercent * 100;

        if (progressValue >= 100)
        {
            progressValue = 100;
        }
        if (progressValue <= 0)
        {
            progressValue = 0;
        }
        progress = progressValue.ToString() + "%";
    }

    #endregion

    #region Public Methods

    public void LevelStart()
    {
        AnalyticsResult analyticsResult = Analytics.CustomEvent(
          "LevelStart",
          new Dictionary<string, object>
          {
                {"Size", ScenarioGenerator.Instance.levelSize}
          }
          );

        print("LevelStart" + analyticsResult);
    }

    public void LevelEnd(float time, string score)
    {
        AnalyticsResult analyticsResult = Analytics.CustomEvent(
          "LevelEnd",
          new Dictionary<string, object>
          {
                {"Size", ScenarioGenerator.Instance.levelSize},
              {"Time", time},
               {"Score", score}
          }
          );

        print("LevelEnd" + analyticsResult);
    }

    public void DeathByMeteor(int count, string score)
    {
        AnalyticsResult analyticsResult = Analytics.CustomEvent(
           "DeathByMeteor",
           new Dictionary<string, object>
           {
                {"DeathByMeteor", count},
                {"Score", score},
               {"Progress", progress}
           }
           );
        print("DeathByMeteor" + analyticsResult);
    }

    public void DeathByFall(int count, string score)
    {
        AnalyticsResult analyticsResult = Analytics.CustomEvent(
           "DeathByFall",
           new Dictionary<string, object>
           {
                {"DeathByFall", count},
                {"Score", score},
                {"Progress", progress}
           }
           );
        print("DeathByFall" + analyticsResult);
    }

    public void ShowAd()
    {
        PlayerPrefs.SetInt("AdsShown", PlayerPrefs.GetInt("AdsShown") + 1);
        AnalyticsResult analyticsResult = Analytics.CustomEvent(
           "ShowAd",
           new Dictionary<string, object>
           {
                {"AdShown", PlayerPrefs.GetInt("AdsShown")}
           }
           );
        print("ShowAd" + analyticsResult);
    }

    #endregion
}
