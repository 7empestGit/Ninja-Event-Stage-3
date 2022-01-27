[System.Serializable]
public class GameData
{
    public int CoinAmount;
    public int SelectedVehicleID;

    #region Audio
    public float SFXVolume;
    public float MusicVolume;
    public bool isSFXMuted;
    public bool isMusicMuted;
    #endregion

    public GameData()
    {
        CoinAmount = 10;
        SelectedVehicleID = 0;
        SFXVolume = 1;
        MusicVolume = 1;
        isMusicMuted = false;
        isSFXMuted = false;
    }
}
