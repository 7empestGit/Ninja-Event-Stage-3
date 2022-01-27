using DynamicBox.SaveManagement;

public static class VehicleDataHandler
{
    private static SaveManager saveManager = new SaveManager(StorageMethod.JSON);

    private static bool isBoughtAndSelected;

    public static void SaveState(VehicleData dataFile, int id)
    {
        saveManager.SaveToFile<VehicleData>(dataFile, $"VehicleData{id}");
    }

    public static VehicleData LoadState(int id)
    {
        isBoughtAndSelected = id == 0 ? true : false;  // first vehicle (id 0) is always bought and selected
        return saveManager.LoadFromFile<VehicleData>(
            $"VehicleData{id}",
            new VehicleData(id, VehicleInfo.VehiclePrices[id], isBoughtAndSelected, isBoughtAndSelected)
            );
    }
}
