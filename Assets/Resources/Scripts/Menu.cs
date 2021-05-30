using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public GameObject optionsObj;
    public GameObject menuObj;
    public Slider volumeSlider, sizeSlider;
    public Text sizeLabel;

   
    void Start()
    {
        sizeLabel.text = PlayerPrefs.GetInt("LevelSize").ToString();
        volumeSlider.value = PlayerPrefs.GetFloat("Volume");
        sizeLabel.text = PlayerPrefs.GetInt("LevelSize").ToString();
        ClearPlayerPrefs();

        if (sizeSlider.value == 0)
        {
            sizeSlider.value = 250;
            UpdateSize();
        }

        UpdateVolume();
        UpdateSize();


    }

    private void ClearPlayerPrefs()
    {
        PlayerPrefs.SetInt("Deaths", 0);
        PlayerPrefs.SetInt("DeathByMeteor", 0);
        PlayerPrefs.SetInt("DeathByFall", 0);
    }

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

    public void PlayBtn()
    {
        SceneManager.LoadScene(1);
    }
}
