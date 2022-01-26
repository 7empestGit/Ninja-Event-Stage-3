[System.Serializable]
public class GameData
{
    public bool isFirstRun;
    public int CoinAmount;
    public int SelectedVehicleID;

    #region Audio
    public float SFXVolume;
    public float MusicVolume;
    public bool isSFXMuted;
    public bool isMusicMuted;
    #endregion
}
