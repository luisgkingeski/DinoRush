using UnityEngine;

public class SoundController : SingletonMonobehaviour<SoundController>
{
    #region References

    public AudioSource jump;
    public AudioSource run;
    public AudioSource death;

    #endregion

    #region MonoBehaviour Callbacks

    void Start()
    {
        SetVolume();
    }

    #endregion

    #region Private Methods

    private void SetVolume()
    {
        jump.volume = PlayerPrefs.GetFloat("Volume");
        run.volume = PlayerPrefs.GetFloat("Volume");
        death.volume = PlayerPrefs.GetFloat("Volume");
    }

    #endregion

    #region Public Methods

    public void PlayJump()
    {
        jump.PlayOneShot(jump.clip);
    }


    public void PlayDeath()
    {
        death.PlayOneShot(death.clip);
    }

    public void PlayRun()
    {
        run.Play();
    }


    public void StopRun()
    {
        run.Stop();
    }

    public void StopAll()
    {
        run.Stop();
        jump.Stop();
        death.Stop();
    }

    #endregion


}
