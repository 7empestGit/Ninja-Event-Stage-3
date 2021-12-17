using UnityEngine;

public class MusicAudioController : MonoBehaviour
{
    [SerializeField] private GameDataSO gameData;
    [SerializeField] private AudioSource audioSource;

    void Start()
    {
        audioSource.volume = gameData.MusicVolume;
        audioSource.mute = gameData.isMusicMuted;
    }

    public void SetActiveMusic(bool value)
    {
        audioSource.mute = value;
        gameData.isMusicMuted = !value;
    }

    public void MusicVolume(float value)
    {
        audioSource.volume = value;
        gameData.MusicVolume = value;
    }
}
