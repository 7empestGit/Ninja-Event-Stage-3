using UnityEngine;

public class MusicAudioController : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    [SerializeField] private AudioSource audioSource;

    void Start()
    {
        // Load data
        gameData = GameDataHandler.LoadState();

        audioSource.volume = gameData.MusicVolume;
        audioSource.mute = gameData.isMusicMuted;
    }

    public void SetActiveMusic(bool value)
    {
        // Load data
        gameData = GameDataHandler.LoadState();

        audioSource.mute = value;
        gameData.isMusicMuted = value;

        // Save data
        GameDataHandler.SaveState(gameData);
    }

    public void MusicVolume(float value)
    {
        // Load data
        gameData = GameDataHandler.LoadState();

        audioSource.volume = value;
        gameData.MusicVolume = value;

        // Save data
        GameDataHandler.SaveState(gameData);
    }
}
