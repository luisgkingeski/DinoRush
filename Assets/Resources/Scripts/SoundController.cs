using UnityEngine;

public class SoundController : SingletonMonobehaviour<SoundController>
{
    public AudioSource jump;
    public AudioSource run;
    public AudioSource death;


    void Start()
    {
        SetVolume();
    }

    void SetVolume()
    {
        jump.volume = PlayerPrefs.GetInt("Volume");
        run.volume = PlayerPrefs.GetInt("Volume");
        death.volume = PlayerPrefs.GetInt("Volume");
    }

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


}
