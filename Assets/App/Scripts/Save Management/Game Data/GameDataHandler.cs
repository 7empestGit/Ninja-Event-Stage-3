using UnityEngine;
using DynamicBox.SaveManagement;

public static class GameDataHandler
{
    private static SaveManager saveManager = new SaveManager(StorageMethod.JSON);

    public static void SaveState(GameData dataFile)
    {
        saveManager.SaveToFile<GameData>(dataFile, "GameData");
    }

    public static GameData LoadState()
    {
        return saveManager.LoadFromFile<GameData>("GameData", new GameData());
    }
}
