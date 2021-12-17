using UnityEngine;

[CreateAssetMenu(fileName = "NewGameData", menuName = "Scriptable Objects/GameDataSO", order = 0)]
public class GameDataSO : ScriptableObject
{
    #region Audio
    public float SFXVolume;
    public float MusicVolume;
    public bool isSFXMuted;
    public bool isMusicMuted;
    #endregion
}
