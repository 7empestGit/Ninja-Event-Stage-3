[System.Serializable]
public class VehicleData
{
    public int VehicleID;
    public int VehiclePrice;
    public bool IsBought;
    public bool IsSelected;

    public VehicleData(int _vehicleId, int _vehiclePrice, bool _isBought, bool _isSelected)
    {
        VehicleID = _vehicleId;
        VehiclePrice = _vehiclePrice;
        IsBought = _isBought;
        IsSelected = _isSelected;
    }
}
