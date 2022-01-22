using UnityEngine;

public class SFXAudioController : MonoBehaviour
{
    [SerializeField] private GameDataSO gameData;
    [SerializeField] private AudioSource[] audioSources;

    void Start()
    {
        foreach (AudioSource audio in audioSources)
        {
            audio.volume = gameData.SFXVolume;
            audio.mute = gameData.isSFXMuted;
        }
    }

    public void SetActiveSFX(bool value)
    {
        Debug.Log("setactivesfx");
        foreach (AudioSource audio in audioSources)
        {
            audio.mute = value;
            gameData.isSFXMuted = value;
        }
    }

    public void SFXVolume(float value)
    {
        foreach (AudioSource audio in audioSources)
        {
            audio.volume = value;
            gameData.SFXVolume = value;
        }
    }
}
