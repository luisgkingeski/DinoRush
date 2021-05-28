using System.Collections.Generic;
using UnityEngine.Analytics;

public class AnalyticsManager : SingletonMonobehaviour<AnalyticsManager>
{
    private string progress;
    private ProgressBar progressBar;

    private void Start()
    {
        progressBar = ProgressBar.Instance;
    }

    private void Update()
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

    public void LevelEnd(float time)
    {
        AnalyticsResult analyticsResult = Analytics.CustomEvent(
          "LevelEnd",
          new Dictionary<string, object>
          {
                {"Size", ScenarioGenerator.Instance.levelSize},
              {"Time", time}
          }
          );

        print("LevelEnd" + analyticsResult);
    }



    public void DeathByMeteor(int count, int score)
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

    public void DeathByFall(int count, int score)
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
        AnalyticsResult analyticsResult = Analytics.CustomEvent(
           "ShowAd",
           new Dictionary<string, object>
           {
                {"AdShown", true}
           }
           );
        print("ShowAd" + analyticsResult);
    }



}
