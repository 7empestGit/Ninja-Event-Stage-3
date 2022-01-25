using UnityEngine;

public class SFXAudioController : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    [SerializeField] private AudioSource[] audioSources;

    void Start()
    {
        // Load data
        gameData = GameDataHandler.LoadState();

        foreach (AudioSource audio in audioSources)
        {
            audio.volume = gameData.SFXVolume;
            audio.mute = gameData.isSFXMuted;
        }
    }

    public void SetActiveSFX(bool value)
    {
        // Load data
        gameData = GameDataHandler.LoadState();
        foreach (AudioSource audio in audioSources)
        {
            audio.mute = value;
            gameData.isSFXMuted = value;
        }
        // Save data
        GameDataHandler.SaveState(gameData);
    }

    public void SFXVolume(float value)
    {
        // Load data
        gameData = GameDataHandler.LoadState();
        foreach (AudioSource audio in audioSources)
        {
            audio.volume = value;
            gameData.SFXVolume = value;
        }
        // Save data
        GameDataHandler.SaveState(gameData);
    }
}
