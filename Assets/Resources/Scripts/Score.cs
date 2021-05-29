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
        scoreTxt.text = "Score: " + score.ToString() + "/" + eggs.Length; ;
    }

    #endregion

    #region Coroutines

    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        eggs = GameObject.FindGameObjectsWithTag("Egg");
        scoreTxt.text = "Score: 0/" + eggs.Length;
    }

    #endregion





}
