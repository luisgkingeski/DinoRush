using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class InitializeADS : MonoBehaviour
{
    #region Variables

    string gameId = "1234567";
    bool testMode = true;

    #endregion

    #region MonoBehaviour Callbacks

    void Start()
    {
        Advertisement.Initialize(gameId, testMode);
    }

    #endregion

}
