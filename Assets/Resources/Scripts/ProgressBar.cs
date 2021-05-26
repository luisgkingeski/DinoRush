using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : SingletonMonobehaviour<ProgressBar>
{
    #region References

    public GameObject player;
    public GameObject final;

    public Image redBar;

    #endregion

    #region Variables

    private float distancePercent;
    private float distance;

    #endregion

    #region MonoBehaviour Callbacks

    private void Update()
    {
        distancePercent = ((player.transform.position.x * 100 )/distance)/100;
        redBar.fillAmount = distancePercent;
    }

    #endregion

    #region Private Methods
    #endregion

    #region Public Methods

    public void SetFinal(GameObject finalObj)
    {
        final = finalObj;
        distance = Vector3.Distance(player.transform.position, final.transform.position);
    }

    #endregion



}
