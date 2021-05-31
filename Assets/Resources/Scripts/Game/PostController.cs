using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PostController : MonoBehaviour
{
    #region References

    public Text status;
    public Text time;
    public Text score;
    private GameObject music;

    #endregion


    #region MonoBehaviour Callbacks

    void Start()
    {
        status.text = "Level " + PlayerPrefs.GetString("Status");
        time.text = "Time: " + PlayerPrefs.GetFloat("Time");
        score.text = "Score: " + PlayerPrefs.GetString("LastScore");
        music = GameObject.Find("Music");
    }

    #endregion

    #region Public Methods

    public void BtnRetry()
    {
        SceneManager.LoadScene("Game");
    }

    public void BtnMenu()
    {
        SceneManager.LoadScene("Menu");
        if (!ReferenceEquals(music, null))
        {
            Destroy(music);
        }
    }

    public void BtnExit()
    {
        Application.Quit();
    }

    #endregion
}
