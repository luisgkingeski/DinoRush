using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    #region References

    public GameObject optionsObj;
    public GameObject menuObj;
    public Slider volumeSlider, sizeSlider;
    public Text sizeLabel;

    #endregion

    #region MonoBehaviour Callbacks

    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume");
        sizeSlider.value = PlayerPrefs.GetInt("LevelSize");
        sizeLabel.text = PlayerPrefs.GetInt("LevelSize").ToString();
        ClearPlayerPrefs();
    }

    #endregion

    #region Private Methods

    private void ClearPlayerPrefs()
    {
        PlayerPrefs.SetInt("Deaths", 0);
        PlayerPrefs.SetInt("DeathByMeteor", 0);
        PlayerPrefs.SetInt("DeathByFall", 0);
    }

    #endregion

    #region Public Methods

    public void UpdateVolume()
    {
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
    }

    public void UpdateSize()
    {
        PlayerPrefs.SetInt("LevelSize", (int)sizeSlider.value);
        sizeLabel.text = PlayerPrefs.GetInt("LevelSize").ToString();
    }

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

    public void BtnPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void BtnExit()
    {
        Application.Quit();
    }

    #endregion
}
