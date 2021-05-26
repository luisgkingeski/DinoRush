using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : SingletonMonobehaviour<Score>
{
    #region References

    public Text scoreTxt;

    #endregion

    #region Variables

    public int score = 0;

    #endregion

    #region MonoBehaviour Callbacks

    void Start()
    {
        scoreTxt.text = "Score: 0 ";
    }

    #endregion

    #region Private Methods
    #endregion

    #region Public Methods

    public void ScoreUp()
    {
        score++;
        scoreTxt.text = "Score: " + score.ToString();
    }

    #endregion
}
