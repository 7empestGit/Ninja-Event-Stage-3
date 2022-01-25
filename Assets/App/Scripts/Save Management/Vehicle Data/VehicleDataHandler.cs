using UnityEngine;
using DynamicBox.SaveManagement;

public static class VehicleDataHandler
{
    private static SaveManager saveManager = new SaveManager(StorageMethod.JSON);

    public static void SaveState(VehicleData dataFile, int id)
    {
        saveManager.SaveToFile<VehicleData>(dataFile, $"VehicleData{id}");
    }

    public static VehicleData LoadState(int id)
    {
        return saveManager.LoadFromFile<VehicleData>($"VehicleData{id}", new VehicleData(0, 0, false, false));
    }
}
