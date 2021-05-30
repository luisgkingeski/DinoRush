using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PostController : MonoBehaviour
{
    public Text status;
    public Text time;
    public Text score;


    void Start()
    {
        status.text = "Level " + PlayerPrefs.GetString("Status");
        time.text = "Time: " + PlayerPrefs.GetFloat("Time");
        score.text = "Score: " + PlayerPrefs.GetString("LastScore");
    }

    public void BtnRetry()
    {
        SceneManager.LoadScene("Game");
    }

    public void BtnMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void BtnExit()
    {
        Application.Quit();
    }

   

}
