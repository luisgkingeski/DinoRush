using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Score : SingletonMonobehaviour<Score>
{
    #region References

    public Text scoreTxt;

    #endregion

    #region Variables

    public int score = 0;
    public string scoreString;
    public int totalScore = 0;
    public GameObject[] eggs;

    #endregion

    #region MonoBehaviour Callbacks

    void Start()
    {
        StartCoroutine(LateStart(0.1f));

    }

    #endregion

    #region Private Methods
    #endregion

    #region Public Methods

    public void ScoreUp()
    {
        score++;
        scoreString = score.ToString() + "/" + eggs.Length;
        scoreTxt.text = "Score: " + scoreString;
    }

    #endregion

    #region Coroutines

    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        eggs = GameObject.FindGameObjectsWithTag("Egg");
        scoreString = score.ToString() + "/" + eggs.Length;
        scoreTxt.text = "Score: " + scoreString;
    }

    #endregion

}
