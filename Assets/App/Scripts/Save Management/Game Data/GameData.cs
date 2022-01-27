[System.Serializable]
public class GameData
{
    public int CoinAmount = 100;
    public int SelectedVehicleID = 0;

    #region Audio
    public float SFXVolume = 1;
    public float MusicVolume = 1;
    public bool isSFXMuted = false;
    public bool isMusicMuted = false;
    #endregion
}
