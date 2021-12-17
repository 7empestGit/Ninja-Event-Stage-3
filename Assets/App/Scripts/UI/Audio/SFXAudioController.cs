using UnityEngine;

public class SFXAudioController : MonoBehaviour
{
    #region Singleton
    public static SFXAudioController instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public AudioSource clickSound;
    [Space]
    [SerializeField] private AudioSource[] audioSources;

    public void SetActiveSFX(bool value)
    {
        foreach(AudioSource audio in audioSources)
        {
            audio.mute = value;
        }
    }

    public void SFXVolume(float value)
    {
        foreach(AudioSource audio in audioSources)
        {
            audio.volume = value;
        }
    }
}
