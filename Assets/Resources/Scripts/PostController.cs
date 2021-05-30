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
    private GameObject music;

    void Start()
    {
        status.text = "Level " + PlayerPrefs.GetString("Status");
        time.text = "Time: " + PlayerPrefs.GetFloat("Time");
        score.text = "Score: " + PlayerPrefs.GetString("LastScore");
        music = GameObject.Find("Music");
    }

    public void BtnRetry()
    {
        SceneManager.LoadScene("Game");
    }

    public void BtnMenu()
    {
        SceneManager.LoadScene("Menu");
        if(!ReferenceEquals(music, null))
        {
            Destroy(music);
        }
    }

    public void BtnExit()
    {
        Application.Quit();
    }

   

}
