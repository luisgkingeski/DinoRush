using UnityEngine;

public class Music : SingletonMonobehaviour<Music>
{
    #region Variables

    private AudioSource audioSource;

    #endregion

    #region MonoBehaviour Callbacks

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        audioSource.volume = PlayerPrefs.GetFloat("Volume");
    }

    #endregion

    #region Public Methods

    public void PlayMusic()
    {
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }

    #endregion
}
