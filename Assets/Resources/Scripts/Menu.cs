using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public GameObject optionsObj;
    public GameObject menuObj;

    public void BtnBack()
    {
        menuObj.SetActive(true);
        optionsObj.SetActive(false);
    }

    public void BtnOptions()
    {
        menuObj.SetActive(false);
        optionsObj.SetActive(true);
    }

    public void PlayBtn()
    {
        SceneManager.LoadScene(1);
    }
}
