using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    [SerializeField] private VehicleData[] vehicleDatas;

    void OnEnable()
    {
        // AutoLoad data on object enables
        if (gameData.isFirstRun)
       {
            gameData.isFirstRun = false;
            // Create GameData
            GameDataHandler.SaveState(gameData);
            // Create VehicleDatas
            for (int i = 0; i < vehicleDatas.Length; i++)
            {
                VehicleDataHandler.SaveState(vehicleDatas[i], i);
            }
       }
        gameData = GameDataHandler.LoadState();
    }

    void OnDisable()
    {
        // AutoSave data on object disables
        GameDataHandler.SaveState(gameData);
    }
}
